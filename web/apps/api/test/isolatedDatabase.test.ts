import { readdirSync, readFileSync } from 'node:fs';
import path from 'node:path';
import { fileURLToPath } from 'node:url';
import { describe, expect, it } from 'vitest';
import {
  assertIsolatedTestDatabase,
  isolatedDatabasePort,
  isolatedDatabaseProblems,
} from './support/isolatedDatabase.js';

/** N49 step 5 (G24): one isolated-database check, and no test that hard-codes the port instead. */
const WEB = path.resolve(path.dirname(fileURLToPath(import.meta.url)), '../../..');
const isolated = {
  DATABASE_URL: 'postgresql://app_user:x@127.0.0.1:55433/datacare?schema=public',
  MIGRATE_DATABASE_URL: 'postgresql://datacare:y@127.0.0.1:55433/datacare?schema=public',
};

describe('isolatedDatabaseProblems', () => {
  it('accepts the disposable database on the default or the configured port', () => {
    expect(isolatedDatabaseProblems(isolated)).toEqual([]);
    expect(isolatedDatabasePort({})).toBe('55433');
    const moved = {
      PARITY_TEST_PORT: '55533',
      PARITY_TEST_DATABASE: 'datacare',
      DATABASE_URL: isolated.DATABASE_URL.replace(':55433', ':55533'),
      MIGRATE_DATABASE_URL: isolated.MIGRATE_DATABASE_URL.replace(
        '127.0.0.1:55433',
        'localhost:55533',
      ),
    };
    expect(isolatedDatabaseProblems(moved)).toEqual([]);
    expect(() => assertIsolatedTestDatabase('fixtures', moved)).not.toThrow();
  });

  it('refuses the application database, another host, another port or another login', () => {
    const app = {
      DATABASE_URL: 'postgresql://app_user:x@127.0.0.1:5433/datacare',
      MIGRATE_DATABASE_URL: 'postgresql://datacare:y@127.0.0.1:5433/datacare',
    };
    expect(isolatedDatabaseProblems(app)).toEqual([
      'DATABASE_URL port 5433 is not 55433',
      'MIGRATE_DATABASE_URL port 5433 is not 55433',
    ]);
    expect(isolatedDatabaseProblems({ ...app, PARITY_TEST_PORT: '5433' })).toContain(
      'PARITY_TEST_PORT 5433 is the application database port',
    );
    expect(
      isolatedDatabaseProblems({
        ...isolated,
        MIGRATE_DATABASE_URL: 'postgresql://datacare:y@db.internal:55433/datacare',
      }),
    ).toEqual(['MIGRATE_DATABASE_URL host db.internal is not loopback']);
    expect(
      isolatedDatabaseProblems({
        ...isolated,
        DATABASE_URL: 'postgresql://datacare:y@127.0.0.1:55433/datacare',
      }),
    ).toEqual(['DATABASE_URL does not log in as app_user']);
    expect(
      isolatedDatabaseProblems({
        ...isolated,
        DATABASE_URL: 'mysql://app_user@127.0.0.1:55433/datacare',
      }),
    ).toEqual(['DATABASE_URL is not a PostgreSQL URL']);
  });

  it('refuses two different databases, or not the one the wrapper created', () => {
    expect(
      isolatedDatabaseProblems({
        ...isolated,
        MIGRATE_DATABASE_URL: 'postgresql://datacare:y@127.0.0.1:55433/other',
      }),
    ).toEqual(['DATABASE_URL and MIGRATE_DATABASE_URL name different databases']);
    expect(isolatedDatabaseProblems({ ...isolated, PARITY_TEST_DATABASE: 'datacare_ci' })).toEqual([
      'the database is not datacare_ci, the one scripts/parity-test-env.mjs created',
    ]);
  });

  it('reports missing or malformed URLs and names the port in the error', () => {
    expect(isolatedDatabaseProblems({})).toEqual([
      'DATABASE_URL is not set',
      'MIGRATE_DATABASE_URL is not set',
    ]);
    expect(isolatedDatabaseProblems({ ...isolated, DATABASE_URL: 'not a url' })).toEqual([
      'DATABASE_URL is not a URL',
    ]);
    expect(() => assertIsolatedTestDatabase('report fixtures', {})).toThrow(
      'report fixtures require the isolated test database on 127.0.0.1:55433: DATABASE_URL is not set',
    );
  });
});

/** Code that compares a URL against the literal isolated port instead of using the shared check. */
export function literalPortChecks(source: string): string[] {
  const code = source.replace(/\/\*[\s\S]*?\*\//g, '').replace(/(^|[^:])\/\/.*$/gm, '$1');
  const pattern =
    /(?:[!=]==\s*['"`]55433['"`])|(?:['"`]55433['"`]\s*[!=]==)|(?:includes\(\s*['"`][^'"`]*:55433)|(?:assert(?:\.strict)?\.equal\([^;]*?['"`]55433['"`])/g;
  return code.match(pattern) ?? [];
}

function sources(dir: string, pattern: RegExp): string[] {
  return readdirSync(dir, { withFileTypes: true }).flatMap((entry) => {
    const full = path.join(dir, entry.name);
    if (entry.isDirectory()) return entry.name === 'node_modules' ? [] : sources(full, pattern);
    return pattern.test(entry.name) ? [full] : [];
  });
}

describe('no hard-coded isolated-database port', () => {
  it('detects a literal port comparison wherever it is written', () => {
    expect(
      literalPortChecks(`
        if (!url || new URL(url).port !== '55433') throw new Error('x');
        if ('55433' === port) {}
        if (!process.env.DATABASE_URL?.includes(':55433/')) throw new Error('y');
        assert.equal(url.port, '55433', 'z');
        // new URL(url).port !== '55433' in a comment is fine
        const message = 'restricted to port 55433';`),
    ).toHaveLength(4);
  });

  it('database tests and the real-stack harness take the port from the shared check or PARITY_TEST_PORT', () => {
    const offenders = [
      ...sources(path.join(WEB, 'apps/api/test'), /\.(ts|mjs)$/),
      ...sources(path.join(WEB, 'apps/web/test'), /\.mjs$/),
      ...sources(path.join(WEB, 'scripts'), /\.mjs$/),
    ]
      .filter((file) => !file.endsWith(path.join('test', 'isolatedDatabase.test.ts')))
      .flatMap((file) =>
        literalPortChecks(readFileSync(file, 'utf8')).map(
          (hit) => `${path.relative(WEB, file)}: ${hit}`,
        ),
      );
    // Use assertIsolatedTestDatabase() (test/support/isolatedDatabase.ts) in a database test, or
    // PARITY_TEST_PORT with the 55433 default in a script, so the suite can run on any isolated port.
    expect(offenders).toEqual([]);
  });
});
