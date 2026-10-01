import { readdirSync, readFileSync } from 'node:fs';
import { dirname, join } from 'node:path';
import { fileURLToPath } from 'node:url';
import { describe, expect, it } from 'vitest';

/**
 * N49 / G23: a journey seed UPDATE that matches no row succeeds silently, so the journey passes on a warm
 * database and fails on a clean one (the tag-split SRNO_MAST seed did exactly that). Every UPDATE statement in a
 * `*.journey.mjs` file must therefore be one of:
 *   - wrapped in `expectRows(n, …)` from `journeySql.mjs`, or inside `assert.equal(…, n)`;
 *   - a cleanup preceded by a comment containing "Idempotent cleanup", which may legitimately match nothing.
 * Upserts (`INSERT … ON CONFLICT … DO UPDATE`) are not UPDATE statements and need no marker.
 */
const here = dirname(fileURLToPath(import.meta.url));
const UPDATE_STATEMENT = /\bUPDATE\s+\\?"/;
const ASSERTED = /\bexpectRows\(|\bassert\.equal\(/;
const CLEANUP_MARKER = /idempotent cleanup/i;
/** How far above an UPDATE line the enclosing statement may start. */
const MAX_STATEMENT_LINES = 8;

/** 1-based line numbers of UPDATE statements that are neither asserted nor marked as idempotent cleanup. */
export function unassertedUpdates(source: string): number[] {
  const lines = source.split('\n');
  const offenders: number[] = [];
  lines.forEach((line, index) => {
    const trimmed = line.trim();
    if (!UPDATE_STATEMENT.test(line) || trimmed.startsWith('//') || trimmed.startsWith('*')) return;
    // Walk up to the start of the enclosing statement: stop at the previous statement's terminator or at a block
    // boundary. Comments directly above the statement belong to it.
    const statement = [line];
    for (let up = index - 1; up >= 0 && index - up <= MAX_STATEMENT_LINES; up--) {
      const above = (lines[up] ?? '').trim();
      if (/[;{}]$/.test(above) && !above.startsWith('//')) break;
      statement.unshift(above);
    }
    const text = statement.join('\n');
    if (!ASSERTED.test(text) && !CLEANUP_MARKER.test(text)) offenders.push(index + 1);
  });
  return offenders;
}

const journeys = readdirSync(here)
  .filter((name) => name.endsWith('.journey.mjs'))
  .sort();

describe('journey fixture UPDATE statements', () => {
  it('finds the journey files', () => {
    expect(journeys.length).toBeGreaterThanOrEqual(20);
  });

  it.each(journeys)('%s asserts every seed UPDATE or marks it as idempotent cleanup', (name) => {
    expect(unassertedUpdates(readFileSync(join(here, name), 'utf8'))).toEqual([]);
  });

  it('catches a planted unasserted seed update', () => {
    const planted = [
      'export async function seedProbe(sql) {',
      '  await sql(`DELETE FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=\'ZZZ\'`);',
      '  await sql(',
      '    `UPDATE "SRNO_MAST" SET "TAG_SRNO"=9000 WHERE tenant_id=$1`,',
      '  );',
      '  await sql(`UPDATE "CO_SET" SET "TRAD_FINE"=\'Y\' WHERE tenant_id=$1`);',
      '}',
    ].join('\n');
    expect(unassertedUpdates(planted)).toEqual([4, 6]);
  });

  it('accepts asserted updates, marked cleanups and upserts', () => {
    const accepted = [
      'export async function seedProbe(sql) {',
      '  await expectRows(',
      '    1,',
      '    sql(`UPDATE "CO_SET" SET "TRAD_FINE"=\'Y\' WHERE tenant_id=$1`),',
      "    'company 01 CO_SET row',",
      '  );',
      '  assert.equal(',
      '    await owner.$executeRawUnsafe(',
      '      `UPDATE "SL_ORD_DATA" SET "MOBILE"=NULL WHERE tenant_id=$1`,',
      '    ),',
      '    1,',
      '  );',
      '  // Idempotent cleanup: may match no row on a clean database.',
      '  await sql(`UPDATE "CO_MAST" SET "CO_PIN"=NULL WHERE tenant_id=$1`);',
      '  await sql(`INSERT INTO "SRNO_MAST"(tenant_id) VALUES($1) ON CONFLICT DO UPDATE SET "TAG_SRNO"=1`);',
      '}',
    ].join('\n');
    expect(unassertedUpdates(accepted)).toEqual([]);
  });
});
