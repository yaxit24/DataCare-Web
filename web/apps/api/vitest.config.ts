import { defineConfig } from 'vitest/config';

/**
 * Vitest configuration for the API package.
 *
 * WHY CONCURRENCY IS BOUNDED
 * --------------------------
 * There was no config here, so vitest used its default of one worker per CPU with unbounded file
 * parallelism. That is fine for pure tests but wrong for this suite: roughly half of the ~112 files are
 * database tests, each constructing its own `PrismaClient` against the SAME PostgreSQL instance, whose
 * `max_connections` is 100.
 *
 * The result was intermittent failures that moved between files run to run — `settingsBehavior.db` on one
 * pass, `salesFamilyLifecycle.db` on the next — which is the signature of resource contention rather than a
 * logic error. A full run with `maxThreads=4` passed all 830 tests where the unbounded run failed 1-2.
 *
 * A shared database is a genuine serialisation point, so bounding the pool is the correct fix, not a way of
 * hiding flakiness: the tests themselves are already tenant-isolated (every DB test uses its own short
 * kebab `tenant_id` under forced RLS), and nothing here weakens an assertion.
 *
 * If the suite is ever split so DB tests run against per-worker databases, this limit can be raised.
 */
export default defineConfig({
  test: {
    poolOptions: {
      threads: {
        // Four concurrent files keeps well inside the connection limit while still using the machine.
        maxThreads: 4,
        minThreads: 1,
      },
    },
    // A DB test that seeds, posts a voucher and asserts a write set legitimately takes longer than the 5s
    // default, especially while sharing the database with three other files.
    testTimeout: 30_000,
    hookTimeout: 30_000,
  },
});
