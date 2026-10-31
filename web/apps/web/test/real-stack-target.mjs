import assert from 'node:assert/strict';
import { readFileSync } from 'node:fs';
import { resolve } from 'node:path';

/**
 * N49 step 4: where a real-stack suite runs.
 *
 * The database is the one scripts/parity-test-env.mjs started (PARITY_TEST_PORT, default 55433, and
 * PARITY_TEST_DATABASE, default datacare). The API and the production Next server listen on
 * PARITY_API_PORT and PARITY_WEB_PORT (defaults 4410 and 4411), so two worktrees can run their suites at
 * the same time. Next fixes API_ORIGIN when it builds (apps/web/next.config.mjs), so the build must have
 * been made with this run's API origin; the check below refuses a mismatched build before anything starts.
 */
export function realStackTarget(root, env = process.env) {
  const dbPort = env.PARITY_TEST_PORT?.trim() || '55433';
  const database = env.PARITY_TEST_DATABASE?.trim() || 'datacare';
  const port = (name, fallback) => {
    const value = Number(env[name]?.trim() || fallback);
    assert(
      Number.isInteger(value) && value >= 1024 && value <= 65535,
      `${name} must be a port from 1024 to 65535`,
    );
    return value;
  };
  const apiPort = port('PARITY_API_PORT', 4410);
  const webPort = port('PARITY_WEB_PORT', 4411);
  assert.notEqual(apiPort, webPort, 'PARITY_API_PORT and PARITY_WEB_PORT must differ');
  for (const name of ['DATABASE_URL', 'MIGRATE_DATABASE_URL']) {
    const url = new URL(env[name] || 'invalid:');
    assert.equal(url.hostname, '127.0.0.1', `${name} must use the disposable local database`);
    assert.equal(url.port, dbPort, `${name} must use the disposable test port ${dbPort}`);
    assert.equal(url.pathname, `/${database}`, `${name} must name the disposable database`);
  }
  assert.equal(new URL(env.DATABASE_URL).username, 'app_user');
  const apiOrigin = `http://127.0.0.1:${apiPort}`;
  const webOrigin = `http://127.0.0.1:${webPort}`;
  const manifest = JSON.parse(
    readFileSync(resolve(root, 'apps/web/.next/routes-manifest.json'), 'utf8'),
  );
  assert(
    JSON.stringify(manifest.rewrites).includes(`${apiOrigin}/:path*`),
    `Build the web app with API_ORIGIN=${apiOrigin} pnpm --filter @datacare/web build before running`,
  );
  return {
    dbPort,
    database,
    apiPort,
    webPort,
    apiOrigin,
    webOrigin,
    /** The result.json `database` field the release certifier reads. */
    databaseLabel: `disposable localhost:${dbPort} / app_user`,
  };
}

/**
 * N205 (G218): refuse to start a suite's servers when something already answers on one of its ports. The new Next
 * server cannot bind a port another server holds and exits, but the readiness probe got a 200 from the old one, so
 * the suite ran against that server's build (seen with a demo stack left on the same ports).
 */
export async function assertPortsFree(target) {
  for (const origin of [target.apiOrigin, target.webOrigin]) {
    let answered = false;
    try {
      await fetch(origin, { signal: AbortSignal.timeout(2000) });
      answered = true;
    } catch {
      // Nothing listening: the connection was refused or timed out.
    }
    assert(
      !answered,
      `${origin} already answers: stop the server using that port, or set PARITY_API_PORT/PARITY_WEB_PORT`,
    );
  }
}
