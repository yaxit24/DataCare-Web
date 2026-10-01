#!/usr/bin/env node
/**
 * Verify that documentation citations resolve against the tree.
 *
 * WHY THIS EXISTS
 * Checking references by hand has caught something NINE times: five reversed rate-cut directions, a 220-line
 * stale export table, the retracted `KR_DETL` write gap, book 043's `CUR_USE`, a ledger total of 5194 that was
 * 5094, a report-slug count of 44 that was 48, a test-typecheck count of 112 that was 114, and two prettier
 * reflows that silently defeated exact-match edits. At that rate the working assumption is that any unverified
 * document is roughly half wrong, which is too high to leave to discipline.
 *
 * WHAT IT CHECKS
 *   1. `path/to/file.ts` in backticks — the file exists.
 *   2. `path/to/file.ts:123` — the file exists AND has at least 123 lines. A line citation that points past the
 *      end of a file is the most common form of drift, because code moves and prose does not.
 *   3. `<!-- verify: <command> == <expected> -->` — runs the command and compares its trimmed stdout. This is
 *      how a NUMERIC claim in prose gets pinned to something reproducible.
 *
 * WHAT IT DELIBERATELY DOES NOT CHECK
 * Prose. A citation resolving proves the file exists at that line, not that the sentence about it is true.
 * This narrows the gap; it does not close it. Per-family comparison records and the completion register are
 * what carry the substantive claims, and they require evidence artifacts the register gate checks separately.
 *
 * Paths resolve against the web workspace first, then the repository root, because desktop sources live in
 * `unified/` one level above `web/`.
 *
 * Usage:
 *   node scripts/check-doc-references.mjs
 *   node scripts/check-doc-references.mjs --verbose
 */
import { execFileSync, execSync } from 'node:child_process';
import { readFile, readdir, stat } from 'node:fs/promises';
import path from 'node:path';
import process from 'node:process';
import { fileURLToPath } from 'node:url';

const here = path.dirname(fileURLToPath(import.meta.url));
const web = path.resolve(here, '..');
const repo = path.resolve(web, '..');
const DOCS = path.resolve(web, 'docs');
const verbose = process.argv.includes('--verbose');

/** Citations that name a thing which is not a file in this tree. */
const NOT_FILES = new Set([
  // Desktop-only artifacts and generic examples.
  'package.json',
  'tsconfig.json',
  'schema.prisma',
]);

const FILE_RE = /`([A-Za-z0-9_@./-]+\.(?:ts|tsx|mjs|cs|json|sql|md))(?::(\d+))?`/g;
const VERIFY_RE = /<!--\s*verify:\s*(.+?)\s*==\s*(.+?)\s*-->/g;
/**
 * A document may cite something that does not exist YET, which a plan legitimately must do.
 *
 * Declared explicitly per document rather than inferred, so a forward reference is a stated intention and a
 * broken reference stays an error. Write `<!-- planned: scripts/check-report-parity.mjs -->` anywhere in the
 * document that cites it.
 */
const PLANNED_RE = /<!--\s*planned:\s*(\S+)\s*-->/g;
/**
 * A document may cite a run output that was produced locally and deliberately never committed - real-stack and
 * Playwright results under the gitignored `test-results/`. Declare it with `<!-- not-retained: path -->` so the
 * citation is a stated fact instead of a broken link. The declaration is checked: the path must be gitignored
 * output, so it cannot hide a source or evidence file that belongs in the tree.
 */
const NOT_RETAINED_RE = /<!--\s*not-retained:\s*(\S+)\s*-->/g;

/** True when git ignores `cited` relative to the web workspace or the repository root. */
function isIgnoredOutput(cited) {
  for (const base of [web, repo]) {
    try {
      execFileSync('git', ['check-ignore', '-q', path.resolve(base, cited)], {
        cwd: repo,
        stdio: 'ignore',
      });
      return true;
    } catch {
      /* not ignored from this base; try the next */
    }
  }
  return false;
}

/**
 * Prefixes the docs legitimately omit.
 *
 * The documents cite modules the way a reader thinks about them - `sales/sales.ts`, `gst/gst.ts`,
 * `test/support/footprint.ts` - rather than by full path from the workspace root. That is a deliberate and
 * readable convention, so the checker resolves it instead of demanding the docs become less readable. The
 * first version of this script rejected 60 such citations, which would have been a checker defect reported as
 * 60 documentation defects.
 */
const PREFIXES = [
  '',
  'apps/api/src/modules/',
  'apps/api/src/',
  'apps/api/',
  'apps/web/',
  'packages/db/',
  'packages/core/',
  'unified/src/csharp/DataCareNext/',
  // Documents cite their siblings relatively - README points at `comparisons/family-01-sale.md`.
  'docs/',
];

async function resolveCitation(cited) {
  for (const base of [web, repo]) {
    for (const prefix of PREFIXES) {
      const p = path.resolve(base, prefix + cited);
      try {
        const s = await stat(p);
        if (s.isFile()) return p;
      } catch {
        /* try the next candidate */
      }
    }
  }
  return null;
}

async function lineCount(file) {
  const t = await readFile(file, 'utf8');
  return t.split('\n').length;
}

async function main() {
  // Recursive, so per-family comparison records under docs/comparisons/ are checked too. The first version
  // globbed docs/*.md only, which silently left a whole subdirectory unverified the moment one was created.
  const walk = async (dir) => {
    const out = [];
    for (const entry of await readdir(dir, { withFileTypes: true })) {
      const full = path.join(dir, entry.name);
      if (entry.isDirectory()) out.push(...(await walk(full)));
      else if (entry.name.endsWith('.md')) out.push(full);
    }
    return out;
  };
  const files = await walk(DOCS);
  const problems = [];
  let checkedFiles = 0;
  let checkedLines = 0;
  let checkedClaims = 0;

  for (const docPath of files) {
    const name = path.relative(DOCS, docPath);
    const text = await readFile(docPath, 'utf8');

    const planned = new Set([...text.matchAll(PLANNED_RE)].map((m) => m[1]));
    const notRetained = new Set([...text.matchAll(NOT_RETAINED_RE)].map((m) => m[1]));
    for (const cited of notRetained) {
      if (!isIgnoredOutput(cited)) {
        problems.push(
          `${name}: not-retained declaration for a path git does not ignore -> ${cited}`,
        );
      }
    }

    for (const m of text.matchAll(FILE_RE)) {
      const [, cited, lineNo] = m;
      if (NOT_FILES.has(cited) || !cited.includes('/') || planned.has(cited)) continue;
      if (notRetained.has(cited)) continue;
      checkedFiles += 1;
      const resolved = await resolveCitation(cited);
      if (!resolved) {
        problems.push(`${name}: cited file does not exist -> ${cited}`);
        continue;
      }
      if (lineNo) {
        checkedLines += 1;
        const n = await lineCount(resolved);
        if (Number(lineNo) > n) {
          problems.push(`${name}: ${cited}:${lineNo} points past the end of the file (${n} lines)`);
        }
      }
    }

    for (const m of text.matchAll(VERIFY_RE)) {
      const [, cmd, expected] = m;
      checkedClaims += 1;
      let got = '';
      try {
        got = execSync(cmd, {
          cwd: web,
          encoding: 'utf8',
          stdio: ['ignore', 'pipe', 'ignore'],
        }).trim();
      } catch (e) {
        problems.push(`${name}: verify command failed -> ${cmd}  (${e.message.split('\n')[0]})`);
        continue;
      }
      if (got !== expected.trim()) {
        problems.push(
          `${name}: claim is stale -> ${cmd}\n      expected ${expected.trim()}, got ${got}`,
        );
      }
    }
  }

  console.log(
    `doc references: ${files.length} document(s), ${checkedFiles} file citation(s), ` +
      `${checkedLines} with a line number, ${checkedClaims} verifiable claim(s)`,
  );
  if (verbose && !checkedClaims) {
    console.log(
      '  no <!-- verify: cmd == expected --> claims yet; numeric claims in prose are still unpinned',
    );
  }
  if (problems.length) {
    console.log(`DOC_REFS_RED ${problems.length} problem(s)`);
    for (const p of problems.slice(0, 40)) console.log(`    ${p}`);
    process.exit(1);
  }
  console.log('DOC_REFS_OK every cited path resolves and every pinned claim holds');
}

main().catch((e) => {
  console.error('DOC_REFS_FAIL', e?.message ?? e);
  process.exit(1);
});
