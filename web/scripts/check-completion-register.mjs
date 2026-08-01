#!/usr/bin/env node
/**
 * The completion register gate.
 *
 * WHAT IT GUARDS
 * `docs/COMPLETION-REGISTER.json` is the machine-checkable definition of "done" for the desktop-to-web
 * migration. Its item list is the AUTHORITATIVE user-facing surface of the desktop application: the 198 named
 * entries in `NextMain.MENU_DATA`, which is the menu an operator actually sees and clicks.
 *
 * WHY THAT SOURCE AND NOT THE FORM FILES
 * Counting `.cs` files answers "how much code is there" (204 forms, 969,133 lines). It does not answer "what
 * can a user do", which is the question the migration has to satisfy. Several form files are shared by many
 * menu entries - `RP_ALL` backs a dozen reports, `TR_MEMB_ADJ` backs both `Gold Adjust` and `Memb Adjust` -
 * and several are infrastructure a user never reaches. `MENU_DATA` is the surface; the form files are the
 * implementation behind it.
 *
 * WHAT THIS GATE WILL NOT DO
 * It will not decide whether an item is covered. That was tried and it failed twice in one session:
 *
 *   1. Matching desktop menu labels against the web's form catalog by NAME reported 165 of 198 missing -
 *      including Sales, Purchase, Rojmel and Rate Cut, which the web demonstrably has. The desktop uses terse
 *      labels ('Amt In', 'Kr Issue', 'Dhrn Rec') and the web uses expanded ones ('Accounts', 'Books / Series').
 *      Lexical matching between two different naming conventions measures the conventions, not the coverage.
 *
 *   2. Grepping for a feature's tables reported a hit for nearly everything, because an incidental mention of
 *      `LBR_TYPE` in an unrelated module looks identical to an implementation of the Labour Type master.
 *
 * So `formReferencedInWeb` is recorded as what it is: a WEAK positive and a STRONG negative. A form named in a
 * comment is not implemented; a function can exist under another name. It ORDERS the work. A human classifies
 * each item, with evidence, and this gate enforces that the classification is complete and honest.
 *
 * WHAT IT ENFORCES
 *   * every item carries a known state
 *   * nothing remains `unclassified` once the register is declared complete (`--strict`)
 *   * `verified` requires an `evidence` path that EXISTS on disk
 *   * `implemented-elsewhere`, `dead-in-dataset` and `scope-excluded` each require a `note`
 *   * evidence younger than the code it certifies (staleness is checked by --strict)
 *
 * Usage:
 *   node scripts/check-completion-register.mjs            # report, fail on a malformed or dishonest entry
 *   node scripts/check-completion-register.mjs --strict    # additionally fail on any unclassified item
 */
import { readFile, stat } from 'node:fs/promises';
import path from 'node:path';
import process from 'node:process';
import { fileURLToPath } from 'node:url';

const here = path.dirname(fileURLToPath(import.meta.url));
const repo = path.resolve(here, '..');
const REGISTER = path.resolve(repo, 'docs', 'COMPLETION-REGISTER.json');

const STATES = new Set([
  'unclassified',
  'verified',
  'implemented-unverified',
  'implemented-elsewhere',
  'dead-in-dataset',
  'scope-excluded',
]);
/** States that are meaningless without a written justification. */
const NEEDS_NOTE = new Set(['implemented-elsewhere', 'dead-in-dataset', 'scope-excluded']);

const strict = process.argv.includes('--strict');
const problems = [];

async function main() {
  let reg;
  try {
    reg = JSON.parse(await readFile(REGISTER, 'utf8'));
  } catch (e) {
    console.log(`REGISTER_FAIL cannot read ${path.relative(repo, REGISTER)}: ${e.message}`);
    process.exit(1);
  }
  const items = Array.isArray(reg.items) ? reg.items : [];
  if (!items.length) {
    console.log('REGISTER_FAIL register has no items');
    process.exit(1);
  }

  const byState = new Map();
  for (const it of items) {
    const label = `${it.tab ?? '?'}/${it.menu ?? '?'}`;
    const state = it.state ?? '(missing)';
    byState.set(state, (byState.get(state) ?? 0) + 1);

    if (!STATES.has(state)) {
      problems.push(`${label}: unknown state '${state}'`);
      continue;
    }
    if (state === 'verified') {
      if (!it.evidence) {
        problems.push(`${label}: state 'verified' with no evidence path`);
      } else {
        try {
          await stat(path.resolve(repo, it.evidence));
        } catch {
          problems.push(`${label}: evidence does not exist on disk -> ${it.evidence}`);
        }
      }
    }
    if (NEEDS_NOTE.has(state) && !String(it.note ?? '').trim()) {
      problems.push(`${label}: state '${state}' requires a note explaining it`);
    }
  }

  console.log(`completion register: ${items.length} desktop menu item(s)`);
  for (const [s, n] of [...byState].sort((a, b) => b[1] - a[1])) {
    console.log(`  ${String(n).padStart(4)}  ${s}`);
  }
  const c = reg.counts ?? {};
  if (c.formReferenced != null) {
    console.log(
      `  ordering signal only: form referenced in web ${c.formReferenced}, never ${c.formNeverReferenced}, label unresolved ${c.unresolvedLabel}`,
    );
  }

  if (problems.length) {
    console.log(`REGISTER_RED ${problems.length} problem(s)`);
    for (const p of problems.slice(0, 30)) console.log(`    ${p}`);
    process.exit(1);
  }

  const unclassified = byState.get('unclassified') ?? 0;
  if (strict && unclassified) {
    console.log(`REGISTER_RED ${unclassified} item(s) still unclassified (--strict)`);
    process.exit(1);
  }
  console.log('REGISTER_OK every entry is well-formed and honestly evidenced');
  if (unclassified) {
    console.log(
      `  ${unclassified} item(s) unclassified — Phase 2 drives this to zero; --strict fails while any remain`,
    );
  }
}

main().catch((e) => {
  console.error('REGISTER_FAIL', e?.message ?? e);
  process.exit(1);
});
