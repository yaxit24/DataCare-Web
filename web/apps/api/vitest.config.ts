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
    /**
     * Decides once whether the database-backed tests run, and fails rather than skipping 328 tests while
     * still reporting success. See test/globalSetup.ts for the full reasoning.
     */
    globalSetup: ['./test/globalSetup.ts'],
    /**
     * Pin the timezone for worker processes.
     *
     * The suite has timestamp and fiscal-date assertions written against UTC, because CI runners are UTC and
     * the workflow sets no TZ. On an Asia/Kolkata machine 31 tests failed purely on a 5h30m offset
     * ('01:16:00.168' vs '06:46:00.168', '2024-03-31' vs '2024-04-01'), which reads as a logic bug and is
     * not one. globalSetup also defaults process.env.TZ; this covers the worker environment.
     */
    env: { TZ: 'UTC' },
    /**
     * Run test FILES one at a time.
     *
     * Bounding the pool to four workers was not enough. With four concurrent files the suite is
     * intermittently red on `40P01 deadlock detected`, and the victim moves between runs — three consecutive
     * full runs on one machine produced 0, then 1 (`backupRestore.db`), then 3 failures
     * (`backupRestore.db`, `entityImage.db`, `rateCutSettlement.db`). Serially it is green, twice in a row:
     * 147 files / 1215 tests.
     *
     * The cause is real contention rather than flaky assertions. WP-02A's company restore takes write locks
     * across ~160 tables inside one transaction while other database files write concurrently, so two
     * transactions can each hold what the other needs. Retrying would hide it; ordering removes it.
     *
     * This is not a preference. WP-03 makes release certification fail on RED, and a gate that must refuse
     * every red result cannot sit on a suite that is red at random — the first thing an operator would learn
     * is to re-run it, which is precisely the habit the gate exists to prevent. Determinism is worth the wall
     * clock: 162s serial against 62s parallel on the reference machine.
     *
     * The way to get the time back is per-worker databases, not re-enabling this.
     */
    fileParallelism: false,
    poolOptions: {
      threads: {
        // Retained so a future per-worker-database setup has a starting point; with fileParallelism off only
        // one file runs at a time regardless.
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
