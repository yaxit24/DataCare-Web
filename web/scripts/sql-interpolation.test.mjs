import test from 'node:test';
import assert from 'node:assert/strict';
import ts from 'typescript';
import { findUnsafeSqlInterpolations, SQL_BUILDER_CALLS } from './sql-interpolation.mjs';

/**
 * N94/G79: the SQL raw-interpolation gate must FLAG a request/input value reaching a raw-SQL template and
 * must NOT flag the vetted forms (bound `$n` placeholders, identifier sanitizers, SQL fragments). A gate
 * that cannot fail on a planted violation is theatre, so this proves both directions.
 */
const flagged = (code) => {
  const src = ts.createSourceFile('x.ts', code, ts.ScriptTarget.Latest, true, ts.ScriptKind.TS);
  return findUnsafeSqlInterpolations(src).length > 0;
};

test('flags a request/input value interpolated into a raw-SQL template', () => {
  assert.equal(flagged('tx.$queryRawUnsafe(`WHERE x=${req.body.x}`)'), true);
  assert.equal(flagged('tx.$queryRawUnsafe(`WHERE x=${request.query.name}`)'), true);
  assert.equal(flagged('tx.$executeRawUnsafe(`DELETE WHERE k=${input.key}`)'), true);
  assert.equal(flagged('tx.$queryRawUnsafe(`SELECT ${body[field]}`)'), true);
  assert.equal(flagged('tx.$queryRawUnsafe(`SELECT ${params.name}`)'), true);
  assert.equal(flagged('tx.$queryRawUnsafe(`SELECT ${"a" + req.body.x}`)'), true);
  assert.equal(flagged('tx.$queryRawUnsafe(`${f ? req.body.x : ""}`)'), true);
  // Nested SQL-fragment template that still smuggles a request value is caught.
  assert.equal(flagged('tx.$queryRawUnsafe(`${f ? `WHERE x=${req.body.x}` : ``}`)'), true);
});

test('does not flag bound placeholders, sanitizers and SQL fragments', () => {
  assert.equal(flagged('tx.$queryRawUnsafe(`x=$${params.length + 1}`)'), false);
  assert.equal(flagged('tx.$queryRawUnsafe(`ANY($${params.indexOf(codes) + 1})`)'), false);
  assert.equal(flagged('tx.$queryRawUnsafe(`SELECT ${n("A.X")}`)'), false);
  assert.equal(flagged('tx.$queryRawUnsafe(`FROM ${quoteIdent(table)}`)'), false);
  assert.equal(flagged('tx.$queryRawUnsafe(`1 ${branchWhere}`)'), false);
  assert.equal(flagged('tx.$queryRawUnsafe(`SELECT ${sqlProjection}`)'), false);
  assert.equal(flagged('tx.$queryRawUnsafe(`WHERE ${conds.join(" AND ")}`)'), false);
  assert.equal(flagged('tx.$queryRawUnsafe(`${ITM_FINE_SQL}`)'), false);
  // A non-raw method with an interpolation is irrelevant to this gate.
  assert.equal(flagged('tx.$queryRaw`WHERE x=${req.body.x}`'), false);
});

test('the SQL-builder allow-list is explicit and non-empty', () => {
  assert.ok(SQL_BUILDER_CALLS.has('quoteIdent'));
  assert.ok(SQL_BUILDER_CALLS.size >= 10);
});
