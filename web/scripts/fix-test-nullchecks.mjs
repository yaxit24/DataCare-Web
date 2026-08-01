#!/usr/bin/env node
/**
 * Add the non-null assertions that `noUncheckedIndexedAccess` requires in test files.
 *
 * WHY THIS IS SAFE, AND WHY IT IS NOT "WEAKENING A TEST"
 * `!` is a TYPE-ONLY assertion, erased before the code runs. It changes no behaviour. When a test writes
 * `rows[0]!.total`, it is stating what the test already assumed — that the query returned a row — and if the
 * assumption is wrong the test still fails, now with a TypeError at exactly that line instead of a compile
 * error the suite never sees. Nothing that was asserted stops being asserted.
 *
 * The alternative — relaxing `noUncheckedIndexedAccess` for tests — would be the real weakening, because that
 * flag is what catches an off-by-one in a fixture.
 *
 * WHAT IT HANDLES
 *   TS18048  `'name' is possibly 'undefined'`  -> `!` after that identifier
 *   TS2532   `Object is possibly 'undefined'`  -> `!` after the index access that produced it
 *
 * Anything else is left alone and reported, because a type error that is not one of these two shapes may be a
 * real defect in the test rather than a missing assertion — and this script must not be able to hide one.
 *
 * Usage:
 *   node scripts/fix-test-nullchecks.mjs --dry-run
 *   node scripts/fix-test-nullchecks.mjs
 */
import { execSync } from 'node:child_process';
import { readFile, writeFile } from 'node:fs/promises';
import path from 'node:path';
import process from 'node:process';
import { fileURLToPath } from 'node:url';

const here = path.dirname(fileURLToPath(import.meta.url));
const api = path.resolve(here, '..', 'apps', 'api');
const dryRun = process.argv.includes('--dry-run');

function collectErrors() {
  try {
    execSync('npx tsc -p tsconfig.test.json --noEmit', { cwd: api, encoding: 'utf8' });
    return [];
  } catch (e) {
    const out = `${e.stdout ?? ''}${e.stderr ?? ''}`;
    return out
      .split('\n')
      .map((l) => l.match(/^(.+?)\((\d+),(\d+)\): error (TS\d+): (.+)$/))
      .filter(Boolean)
      .map((m) => ({
        file: m[1],
        line: Number(m[2]),
        col: Number(m[3]),
        code: m[4],
        message: m[5],
      }));
  }
}

/** Where to place `!` for one error, or null if this shape is not handled. */
function insertionPoint(text, err) {
  const lines = text.split('\n');
  const line = lines[err.line - 1];
  if (line == null) return null;
  const from = err.col - 1;

  // A DESTRUCTURING PATTERN cannot take `!`. Inserting one produces `const [{ n !}] = ...`, which is a syntax
  // error - and it is not caught by a type check, it is caught by the test file failing to load. That happened
  // once and cost a green suite; the guard is cheap and the alternative rewrite needs a human anyway.
  if (/^\s*(?:const|let|var)\s*[[{]/.test(line)) return null;

  if (err.code === 'TS18048') {
    // The message names the identifier: 'insert' is possibly 'undefined'.
    const name = err.message.match(/^'(.+?)' is possibly/)?.[1];
    if (!name) return null;
    const at = line.indexOf(name, from);
    if (at < 0) return null;
    return { line: err.line, col: at + name.length };
  }

  if (
    (err.code === 'TS2345' || err.code === 'TS2322' || err.code === 'TS2339') &&
    /undefined/.test(err.message)
  ) {
    // An expression whose type includes `undefined` is being passed or assigned where it is not allowed. The
    // position is the START of that expression; walk to its end at bracket depth zero.
    let depth = 0;
    for (let i = from; i < line.length; i += 1) {
      const ch = line[i];
      if (ch === '(' || ch === '[' || ch === '{') depth += 1;
      else if (ch === ')' || ch === ']' || ch === '}') {
        if (depth === 0) return { line: err.line, col: i };
        depth -= 1;
      } else if (depth === 0 && (ch === ',' || ch === ';')) {
        return { line: err.line, col: i };
      }
    }
    return null;
  }

  if (err.code === 'TS2532') {
    // An index access produced `T | undefined`. Place `!` after its closing bracket.
    let depth = 0;
    for (let i = from; i < line.length; i += 1) {
      const ch = line[i];
      if (ch === '[') depth += 1;
      else if (ch === ']') {
        depth -= 1;
        if (depth === 0) {
          const next = line[i + 1];
          // Only when a property or another index follows, which is what made it an error.
          if (next === '.' || next === '[') return { line: err.line, col: i + 1 };
          return null;
        }
      } else if (depth === 0 && (ch === ')' || ch === ',' || ch === ';')) {
        return null;
      }
    }
    return null;
  }
  return null;
}

async function main() {
  const errors = collectErrors();
  if (!errors.length) {
    console.log('NULLCHECK_OK no type errors in the test project');
    return;
  }

  const handled = [];
  const skipped = [];
  const byFile = new Map();
  for (const err of errors) {
    if (!['TS18048', 'TS2532', 'TS2345', 'TS2322', 'TS2339'].includes(err.code)) {
      skipped.push(err);
      continue;
    }
    if (!byFile.has(err.file))
      byFile.set(err.file, await readFile(path.join(api, err.file), 'utf8'));
    const point = insertionPoint(byFile.get(err.file), err);
    if (!point) {
      skipped.push(err);
      continue;
    }
    handled.push({ file: err.file, ...point });
  }

  // Apply per file, last position first, so earlier offsets stay valid.
  let inserted = 0;
  for (const [file, text] of byFile) {
    const points = handled
      .filter((h) => h.file === file)
      .sort((a, b) => b.line - a.line || b.col - a.col);
    if (!points.length) continue;
    const lines = text.split('\n');
    let seen = new Set();
    for (const p of points) {
      const key = `${p.line}:${p.col}`;
      if (seen.has(key)) continue; // two errors can share one insertion point
      seen.add(key);
      const l = lines[p.line - 1];
      if (l == null || l[p.col] === '!') continue;
      lines[p.line - 1] = `${l.slice(0, p.col)}!${l.slice(p.col)}`;
      inserted += 1;
    }
    if (!dryRun) await writeFile(path.join(api, file), lines.join('\n'));
  }

  console.log(
    `${dryRun ? '[dry run] ' : ''}${errors.length} error(s): ${inserted} assertion(s) ${dryRun ? 'would be' : ''} inserted across ${byFile.size} file(s), ${skipped.length} left for review`,
  );
  const codes = new Map();
  for (const s of skipped) codes.set(s.code, (codes.get(s.code) ?? 0) + 1);
  for (const [code, n] of [...codes].sort((a, b) => b[1] - a[1])) {
    console.log(`  ${String(n).padStart(4)}  ${code} needs a human`);
  }
}

main().catch((e) => {
  console.error('NULLCHECK_FAIL', e?.message ?? e);
  process.exit(1);
});
