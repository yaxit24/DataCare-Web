import test from 'node:test';
import assert from 'node:assert/strict';
import { evaluateBudget } from './check-size-budget.mjs';

/**
 * N95/G79: the file-size budget must FLAG a file that grows past its ceiling or a new file past the default
 * cap, and must NOT flag a file at or below its ceiling. A ratchet that cannot fail is theatre.
 */
test('flags a tracked file that grew past its ceiling', () => {
  const r = evaluateBudget(
    { 'routes/txn.ts': 8600 },
    { defaultCap: 1500, ceilings: { 'routes/txn.ts': 8559 } },
  );
  assert.equal(r.violations.length, 1);
  assert.match(r.violations[0], /exceeds its ceiling of 8559/);
});

test('flags a new file over the default cap', () => {
  const r = evaluateBudget({ 'modules/big.ts': 1600 }, { defaultCap: 1500, ceilings: {} });
  assert.equal(r.violations.length, 1);
  assert.match(r.violations[0], /default cap of 1500/);
});

test('does not flag a file at or below its ceiling, and reports a shrunk file', () => {
  const r = evaluateBudget(
    { 'routes/txn.ts': 8000, 'modules/ok.ts': 1500, 'modules/small.ts': 42 },
    { defaultCap: 1500, ceilings: { 'routes/txn.ts': 8559 } },
  );
  assert.equal(r.violations.length, 0);
  // txn.ts shrank below its recorded ceiling → surfaced so --write tightens it (ceilings only fall).
  assert.equal(r.shrunk.length, 1);
  assert.match(r.shrunk[0], /routes\/txn\.ts/);
});

test('a file exactly at the default cap passes', () => {
  const r = evaluateBudget({ 'modules/edge.ts': 1500 }, { defaultCap: 1500, ceilings: {} });
  assert.equal(r.violations.length, 0);
});
