import assert from 'node:assert/strict';

/**
 * Await a fixture statement and fail unless it affected exactly `expected` rows.
 *
 * Journey seeds run against whatever database the harness provides. An UPDATE that matches no row succeeds
 * silently, so a seed that depends on a row created somewhere else passes on a warm database and fails on a
 * clean one, far from the cause. G23 is the real case: the tag-split seed updated an SRNO_MAST row that only
 * the first tag allocation creates, so on a fresh volume its children were numbered RH0001 and the journey
 * failed hundreds of lines later.
 *
 * Every UPDATE in a journey file must therefore be an upsert, go through this helper, sit inside an
 * `assert.equal(…, n)`, or be a cleanup marked "Idempotent cleanup" that may legitimately match nothing.
 * `journeySeedUpdates.test.ts` enforces that rule.
 *
 * @param {number} expected exact number of rows the statement must affect
 * @param {Promise<number>} statement a pending `$executeRawUnsafe` (it resolves to the affected row count)
 * @param {string} what the fixture row(s) the statement targets, for the failure message
 */
export async function expectRows(expected, statement, what) {
  const affected = await statement;
  assert.equal(
    affected,
    expected,
    `${what}: expected the fixture statement to affect ${expected} row(s), it affected ${affected}`,
  );
  return affected;
}
