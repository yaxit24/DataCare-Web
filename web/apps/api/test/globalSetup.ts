/**
 * Vitest global setup — decides ONCE whether the database-backed tests run, and refuses to let them be
 * skipped by accident.
 *
 * THE PROBLEM THIS SOLVES
 * =======================
 * 53 of the 134 test files gate themselves on `RUN_DB_INTEGRITY_TESTS === '1'` (one on
 * `RUN_DB_SECURITY_TESTS`). CI sets those variables; a developer running `pnpm test` does not. The result:
 *
 *     Test Files  85 passed | 49 skipped (134)
 *     Tests       775 passed | 328 skipped (1103)
 *     EXIT=0
 *
 * 30% of the suite — every voucher-posting, RLS and write-set test, i.e. all the assertions that actually
 * establish desktop parity — silently did not run, and the suite reported success. The project's own
 * documentation warns about exactly this ("a vitest run against an unreachable database SKIPS the DB tests
 * rather than failing, which is the same trap in a different costume") and the trap was still live.
 *
 * WHAT THIS DOES
 * ==============
 *   * If a database is reachable, it ENABLES the DB tests automatically. A developer with the local Postgres
 *     up can no longer skip 328 tests without noticing, and does not need to remember two env vars.
 *   * If no database is reachable, it FAILS with instructions — unless `ALLOW_SKIP_DB_TESTS=1` is set, which
 *     makes the decision explicit and visible in the command line rather than implicit in the environment.
 *   * It reports what it decided, so the run is self-describing.
 *
 * Escape hatch, deliberately awkward to type:
 *     ALLOW_SKIP_DB_TESTS=1 pnpm test
 */
import { PrismaClient } from '@prisma/client';
import { isolatedDatabaseProblems } from './support/isolatedDatabase.js';

const FLAGS = ['RUN_DB_INTEGRITY_TESTS', 'RUN_DB_SECURITY_TESTS'] as const;

/**
 * N49 step 5: prove the reachable database is the disposable test database before any test writes to it.
 * The URLs must pass `isolatedDatabaseProblems`; the runtime login must really be `app_user` without
 * superuser or BYPASSRLS; both logins must reach the same database on the same server; and under
 * `scripts/parity-test-env.mjs` the server must be the one it started (`PARITY_TEST_SYSTEM_IDENTIFIER`,
 * from `pg_control_system()`), so a container replaced or a port reassigned mid-run is refused.
 */
async function identityProblems(): Promise<string[]> {
  const problems = isolatedDatabaseProblems();
  if (problems.length) return problems;
  const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL } } });
  const owner = new PrismaClient({
    datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } },
  });
  const identity = `SELECT current_user::text AS name, current_database()::text AS database,
                           (SELECT system_identifier::text FROM pg_control_system()) AS system,
                           r.rolsuper AS superuser, r.rolbypassrls AS bypass
                      FROM pg_roles r WHERE r.rolname = current_user`;
  type Identity = {
    name: string;
    database: string;
    system: string;
    superuser: boolean;
    bypass: boolean;
  };
  try {
    const [login] = await runtime.$queryRawUnsafe<Identity[]>(identity);
    const [server] = await owner.$queryRawUnsafe<Identity[]>(identity);
    if (!login || !server) return ['the database did not report its identity'];
    if (login.name !== 'app_user')
      problems.push(`the runtime login is ${login.name}, not app_user`);
    if (login.superuser || login.bypass)
      problems.push('the runtime role is a superuser or bypasses row-level security');
    if (login.database !== server.database || login.system !== server.system)
      problems.push('DATABASE_URL and MIGRATE_DATABASE_URL reach different databases or servers');
    const expected = process.env.PARITY_TEST_SYSTEM_IDENTIFIER?.trim();
    if (expected && server.system !== expected)
      problems.push(
        `the server's system identifier ${server.system} is not ${expected}, the one ` +
          'scripts/parity-test-env.mjs started',
      );
  } catch (e) {
    problems.push(
      `could not read the database identity: ${String((e as Error)?.message ?? e).split('\n')[0]}`,
    );
  } finally {
    await runtime.$disconnect().catch(() => {});
    await owner.$disconnect().catch(() => {});
  }
  return problems;
}

function dsn(): string | undefined {
  const v = process.env.DATABASE_URL?.trim() || process.env.MIGRATE_DATABASE_URL?.trim();
  return v || undefined;
}

async function reachable(url: string): Promise<{ ok: boolean; detail: string }> {
  const client = new PrismaClient({ datasources: { db: { url } } });
  try {
    // A trivial query proves the server accepts a connection AND authenticates, which a bare TCP probe
    // does not. Port-open was the weaker check and would have called a wrong-password setup "reachable".
    await client.$queryRawUnsafe('SELECT 1');
    return { ok: true, detail: 'connected' };
  } catch (e) {
    // Prisma's message often starts with a blank line, which produced an empty, unhelpful detail. Take the
    // first non-empty line and fall back to the error name so the failure always says something.
    const msg = (e as Error)?.message ?? String(e);
    const line =
      msg
        .split('\n')
        .map((s) => s.trim())
        .find((s) => s.length > 0) ??
      (e as Error)?.name ??
      'unknown error';
    return { ok: false, detail: line.slice(0, 200) };
  } finally {
    await client.$disconnect().catch(() => {});
  }
}

export default async function setup() {
  // Determinism: the suite contains timestamp and fiscal-date assertions written against UTC (CI runners
  // default to UTC and the workflow sets no TZ). Running in Asia/Kolkata produced 31 failures that were
  // purely a 5h30m offset — '01:16:00.168' vs '06:46:00.168' — which looks like a logic bug and is not one.
  // Pinning it here means the same result on a developer machine and in CI.
  if (!process.env.TZ) process.env.TZ = 'UTC';

  const url = dsn();
  const allowSkip = process.env.ALLOW_SKIP_DB_TESTS === '1';

  if (!url) {
    if (allowSkip) {
      console.warn(
        '[vitest] no DATABASE_URL — database-backed tests SKIPPED because ALLOW_SKIP_DB_TESTS=1.\n' +
          '         This run does NOT establish posting or RLS behaviour.',
      );
      return;
    }
    throw new Error(
      'No DATABASE_URL/MIGRATE_DATABASE_URL is set, so 53 database-backed test files would silently skip\n' +
        'and the run would still report success.\n\n' +
        'Either point the suite at a database:\n' +
        "  export DATABASE_URL='postgresql://app_user:...@127.0.0.1:55433/datacare?schema=public'\n" +
        'or state that you accept an incomplete run:\n' +
        '  ALLOW_SKIP_DB_TESTS=1 pnpm test',
    );
  }

  const { ok, detail } = await reachable(url);
  if (!ok) {
    if (allowSkip) {
      console.warn(
        `[vitest] database unreachable (${detail}) — database-backed tests SKIPPED because ` +
          'ALLOW_SKIP_DB_TESTS=1.\n         This run does NOT establish posting or RLS behaviour.',
      );
      return;
    }
    throw new Error(
      `DATABASE_URL is set but the database is unreachable: ${detail}\n\n` +
        'Left alone, the 53 database-backed test files would skip and the suite would still exit 0.\n' +
        'Start the database, or run with ALLOW_SKIP_DB_TESTS=1 to accept an incomplete run.',
    );
  }

  // Reachable is not enough: the tests delete rows, so the database must be the disposable one.
  const problems = await identityProblems();
  if (problems.length) {
    if (allowSkip) {
      for (const f of FLAGS) process.env[f] = '0';
      console.warn(
        `[vitest] the reachable database is not the isolated test database (${problems.join('; ')}) — ` +
          'database-backed tests SKIPPED because ALLOW_SKIP_DB_TESTS=1.',
      );
      return;
    }
    throw new Error(
      'The reachable database is not the isolated test database, so the database tests will not run:\n  - ' +
        problems.join('\n  - ') +
        '\n\nRun them through scripts/parity-test-env.mjs, or point DATABASE_URL (app_user) and ' +
        'MIGRATE_DATABASE_URL at the same disposable database on 127.0.0.1 and PARITY_TEST_PORT ' +
        '(default 55433).',
    );
  }

  // Reachable: turn the DB tests on so they cannot be missed by forgetting a variable.
  const enabled: string[] = [];
  for (const f of FLAGS) {
    if (process.env[f] !== '1') {
      process.env[f] = '1';
      enabled.push(f);
    }
  }
  console.log(
    `[vitest] database reachable — database-backed tests ENABLED` +
      (enabled.length ? ` (auto-set ${enabled.join(', ')})` : '') +
      `, TZ=${process.env.TZ}`,
  );
}
