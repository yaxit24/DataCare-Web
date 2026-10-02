/**
 * N49 (G24): the one check every database test makes before it touches a database.
 *
 * Database tests insert and delete rows freely, so they may only ever reach the disposable test database:
 *
 *   - a loopback host;
 *   - the isolated port, `PARITY_TEST_PORT` (default 55433), never the application's 5433;
 *   - the same database for the owner (`MIGRATE_DATABASE_URL`) and runtime (`DATABASE_URL`) URLs, and the
 *     database `scripts/parity-test-env.mjs` created when it says so (`PARITY_TEST_DATABASE`);
 *   - the runtime URL logs in as `app_user`.
 *
 * `test/globalSetup.ts` checks this once, together with the server's system identifier and the runtime role's
 * real flags, before it enables the database tests. Each database test also calls
 * `assertIsolatedTestDatabase()` in its setup, so a file run outside the suite cannot slip past.
 * `test/isolatedDatabase.test.ts` fails on a test that compares the port literally instead.
 */
export const DEFAULT_ISOLATED_DATABASE_PORT = '55433';
const APPLICATION_DATABASE_PORT = '5433';
const LOOPBACK_HOSTS = new Set(['127.0.0.1', 'localhost', '[::1]', '::1']);
const URL_NAMES = ['DATABASE_URL', 'MIGRATE_DATABASE_URL'] as const;

type Environment = Record<string, string | undefined>;

/** The port the isolated database listens on for this run. */
export function isolatedDatabasePort(env: Environment = process.env): string {
  return env.PARITY_TEST_PORT?.trim() || DEFAULT_ISOLATED_DATABASE_PORT;
}

/** Every reason the configured URLs are not the isolated test database; empty when they are. */
export function isolatedDatabaseProblems(env: Environment = process.env): string[] {
  const port = isolatedDatabasePort(env);
  const problems: string[] = [];
  if (port === APPLICATION_DATABASE_PORT)
    problems.push(`PARITY_TEST_PORT ${port} is the application database port`);
  const databases = new Set<string>();
  for (const name of URL_NAMES) {
    const raw = env[name]?.trim();
    if (!raw) {
      problems.push(`${name} is not set`);
      continue;
    }
    let url: URL;
    try {
      url = new URL(raw);
    } catch {
      problems.push(`${name} is not a URL`);
      continue;
    }
    if (url.protocol !== 'postgresql:' && url.protocol !== 'postgres:')
      problems.push(`${name} is not a PostgreSQL URL`);
    if (!LOOPBACK_HOSTS.has(url.hostname))
      problems.push(`${name} host ${url.hostname} is not loopback`);
    if (url.port !== port) problems.push(`${name} port ${url.port || '(default)'} is not ${port}`);
    const database = decodeURIComponent(url.pathname.replace(/^\//, ''));
    if (!database) problems.push(`${name} names no database`);
    else databases.add(database);
    if (name === 'DATABASE_URL' && decodeURIComponent(url.username) !== 'app_user')
      problems.push('DATABASE_URL does not log in as app_user');
  }
  if (databases.size > 1)
    problems.push('DATABASE_URL and MIGRATE_DATABASE_URL name different databases');
  const expected = env.PARITY_TEST_DATABASE?.trim();
  if (expected && databases.size === 1 && !databases.has(expected))
    problems.push(`the database is not ${expected}, the one scripts/parity-test-env.mjs created`);
  return problems;
}

/** Throws unless both database URLs point at the isolated test database. */
export function assertIsolatedTestDatabase(
  label = 'database test fixtures',
  env: Environment = process.env,
): void {
  const problems = isolatedDatabaseProblems(env);
  if (problems.length)
    throw new Error(
      `${label} require the isolated test database on 127.0.0.1:${isolatedDatabasePort(env)}: ` +
        problems.join('; '),
    );
}
