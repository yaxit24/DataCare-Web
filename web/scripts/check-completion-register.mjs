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
 *   * `verified` requires an `evidence` path that is a real, NON-EMPTY FILE
 *   * `implemented-elsewhere`, `dead-in-dataset`, `scope-excluded` and `absent` each require a `note`
 *   * a state that claims a web surface must carry one, and one that denies it must not
 *   * the item list matches its own declared count, with no duplicate tab/menu pair
 *
 * WHAT IT DELIBERATELY DOES NOT DO
 * It does not resolve a `webSurface` claim. Whether `GET /reports/day-book` is a real route, `accounts` a real
 * dynamic master, or a page path a real file is decided by the actual route registry and the filesystem, so
 * that check lives in `apps/api/test/completionRegister.test.ts` where `routePolicyFor` can be imported and
 * dynamic families such as `POST /masters/:name/import` resolve correctly. A text search in this script would
 * report a false negative on exactly those, and a gate that cries wolf gets bypassed.
 *
 * TWO DIFFERENT BARS, DELIBERATELY SEPARATE
 *   `--strict`  is WP-04's bar: every entry is CLASSIFIED. It says nothing about whether the classification is
 *               a good one, only that no entry is still `unclassified`.
 *   `--release` is the plan's §11.2/§14 bar: every visible entry is `verified`, or `scope-excluded`/
 *               `dead-in-dataset` with a recorded decision. §14 states it outright — "implemented-unverified
 *               is not done" — and an `absent` entry is a missing feature, so neither may pass a release.
 *
 * Keeping them apart is what stops a completed classification from being read as a completed migration. After
 * WP-04, `--strict` passes and `--release` fails on all 198, which is the true position: we now know exactly
 * what is missing and exactly what is unproven, and knowing is not shipping.
 *
 * Usage:
 *   node scripts/check-completion-register.mjs                       # well-formedness
 *   node scripts/check-completion-register.mjs --strict              # WP-04: nothing unclassified
 *   node scripts/check-completion-register.mjs --strict --release    # release: nothing unproven or missing
 */
import { readFile, stat } from 'node:fs/promises';
import path from 'node:path';
import process from 'node:process';
import { fileURLToPath } from 'node:url';

const here = path.dirname(fileURLToPath(import.meta.url));
const repo = path.resolve(here, '..');
const argValue = (flag) => {
  const i = process.argv.indexOf(flag);
  return i >= 0 ? process.argv[i + 1] : undefined;
};
const REGISTER = path.resolve(
  argValue('--register') ?? path.resolve(repo, 'docs', 'COMPLETION-REGISTER.json'),
);
/**
 * N85 (G71): the menu catalog is the per-menu join of the desktop dispatch and the web surfaces, and
 * `docs/tools/docs_check.py` verifies each catalog row's forms against its `MDI_FORM.cs` dispatch lines and
 * each page and route against the code. Requiring the register to agree with it applies those same rules here
 * without a second, divergent parser: a register row naming a form the dispatch does not open, or a surface
 * the menu does not use, fails.
 */
const CATALOG = path.resolve(
  argValue('--catalog') ?? path.resolve(repo, '..', 'docs', 'handbook', 'menu-catalog.jsonl'),
);

const STATES = new Set([
  'unclassified',
  'verified',
  'implemented-unverified',
  'implemented-elsewhere',
  'dead-in-dataset',
  'scope-excluded',
  // Visible on desktop, no web surface. Added by WP-04 because the six original states could not express it:
  // an unimplemented feature had to be called implemented, elsewhere, dead or excluded, and three of those
  // need evidence a classifier does not have. Forcing that choice is how a register starts lying.
  'absent',
]);
/** States that are meaningless without a written justification. */
const NEEDS_NOTE = new Set([
  'implemented-elsewhere',
  'dead-in-dataset',
  'scope-excluded',
  'absent',
]);
/** States that assert a web surface exists, and must therefore name it. */
const NEEDS_SURFACE = new Set(['verified', 'implemented-unverified', 'implemented-elsewhere']);
/** States that assert nothing exists, and must not quietly carry a surface. */
const FORBIDS_SURFACE = new Set(['absent']);
const SURFACE_KINDS = new Set(['route', 'page', 'form', 'master', 'report']);

const strict = process.argv.includes('--strict');
const release = process.argv.includes('--release');
const problems = [];

/**
 * States a release may contain.
 *
 * `verified` is the only positive one. `scope-excluded` and `dead-in-dataset` are acceptable ONLY because each
 * already requires a written decision, which plan §11.2 additionally expects an owner to have signed.
 */
const RELEASE_ACCEPTABLE = new Set(['verified', 'scope-excluded', 'dead-in-dataset']);

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
  const seen = new Map();
  for (const it of items) {
    const label = `${it.tab ?? '?'}/${it.menu ?? '?'}`;
    const state = it.state ?? '(missing)';
    byState.set(state, (byState.get(state) ?? 0) + 1);

    // A duplicated menu entry would let one classification stand in for two desktop actions.
    if (seen.has(label)) problems.push(`${label}: duplicate entry`);
    seen.set(label, true);

    if (!STATES.has(state)) {
      problems.push(`${label}: unknown state '${state}'`);
      continue;
    }
    if (state === 'verified') {
      if (!it.evidence) {
        problems.push(`${label}: state 'verified' with no evidence path`);
      } else {
        // A directory or an empty file satisfied the previous check, which is not evidence of anything.
        try {
          const st = await stat(path.resolve(repo, it.evidence));
          if (!st.isFile()) problems.push(`${label}: evidence is not a file -> ${it.evidence}`);
          else if (st.size === 0)
            problems.push(`${label}: evidence file is empty -> ${it.evidence}`);
        } catch {
          problems.push(`${label}: evidence does not exist on disk -> ${it.evidence}`);
        }
      }
    }
    if (NEEDS_NOTE.has(state) && !String(it.note ?? '').trim()) {
      problems.push(`${label}: state '${state}' requires a note explaining it`);
    }
    if (NEEDS_SURFACE.has(state)) {
      const surface = it.webSurface;
      if (!surface || typeof surface !== 'object') {
        problems.push(`${label}: state '${state}' claims a web equivalent but names no webSurface`);
      } else {
        if (!SURFACE_KINDS.has(surface.kind)) {
          problems.push(`${label}: webSurface.kind '${surface.kind}' is not a known kind`);
        }
        if (!String(surface.surface ?? '').trim()) {
          problems.push(`${label}: webSurface has no surface value`);
        }
      }
    }
    if (FORBIDS_SURFACE.has(state) && it.webSurface) {
      problems.push(`${label}: state '${state}' must not carry a webSurface`);
    }
  }

  // N85: agreement with the dispatch-verified menu catalog.
  let catalogRows;
  try {
    catalogRows = (await readFile(CATALOG, 'utf8'))
      .split('\n')
      .filter((line) => line.trim())
      .map((line) => JSON.parse(line));
  } catch (e) {
    problems.push(`cannot read the menu catalog ${path.relative(repo, CATALOG)}: ${e.message}`);
    catalogRows = [];
  }
  const catalog = new Map(catalogRows.map((row) => [row.id, row]));
  for (const it of items) {
    const label = `${it.tab ?? '?'}/${it.menu ?? '?'}`;
    const row = catalog.get(label);
    if (!row) {
      problems.push(`${label}: no menu catalog row`);
      continue;
    }
    const registerForms = [...(it.desktopForms ?? [])].sort();
    const catalogForms = [...(row.forms ?? [])].sort();
    if (JSON.stringify(registerForms) !== JSON.stringify(catalogForms)) {
      problems.push(
        `${label}: desktop forms [${registerForms.join(', ')}] differ from the dispatch [${catalogForms.join(', ')}]`,
      );
    }
    const surface = it.webSurface;
    if (surface && typeof surface === 'object') {
      const value = String(surface.surface ?? '');
      const pages = (row.ui ?? []).map((ui) => `web/apps/web/app/(app)${ui}/page.tsx`);
      const masters = (row.ui ?? [])
        .filter((ui) => ui.startsWith('/masters/'))
        .map((ui) => ui.slice('/masters/'.length));
      const known =
        (row.api ?? []).includes(value) ||
        pages.includes(value) ||
        (surface.kind === 'master' && masters.includes(value)) ||
        (surface.kind === 'report' && (row.ui ?? []).includes(`/reports/${value}`)) ||
        (row.ui ?? []).includes(value);
      if (!known) {
        problems.push(
          `${label}: web surface ${surface.kind} '${value}' is not one the menu uses (catalog ui ${JSON.stringify(row.ui ?? [])})`,
        );
      }
    }
    if (
      it.state === 'absent' &&
      ((row.ui ?? []).length || (row.api ?? []).length) &&
      row.status !== 'MISSING'
    ) {
      problems.push(`${label}: absent in the register but the catalog lists a web surface`);
    }
  }

  // The register's own declared total is the denominator every release claim cites; a silent drift in the
  // item list would move that denominator without anyone deciding to.
  const declared = reg.counts?.items;
  if (declared != null && declared !== items.length) {
    problems.push(`register declares counts.items=${declared} but carries ${items.length} items`);
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

  if (release) {
    // Plan §14: "'Implemented-unverified' is not done." §11.2: every evaluated-visible entry is verified or
    // mapped, and every excluded or dead entry carries an owner-signed consequence. So a release may contain
    // neither an unproven entry nor a missing one.
    const blocking = items.filter((it) => !RELEASE_ACCEPTABLE.has(it.state));
    if (blocking.length) {
      const counts = new Map();
      for (const it of blocking) counts.set(it.state, (counts.get(it.state) ?? 0) + 1);
      console.log(
        `REGISTER_RED ${blocking.length} of ${items.length} item(s) cannot be released (--release)`,
      );
      for (const [state, n] of [...counts].sort((a, b) => b[1] - a[1])) {
        console.log(`    ${String(n).padStart(4)}  ${state}`);
      }
      const absent = blocking.filter((it) => it.state === 'absent');
      if (absent.length) {
        console.log(
          `    ${absent.length} entr${absent.length === 1 ? 'y has' : 'ies have'} no web surface at all:`,
        );
        for (const it of absent.slice(0, 12)) {
          console.log(`      ${it.tab}/${it.menu}`);
        }
        if (absent.length > 12) console.log(`      … and ${absent.length - 12} more`);
        const hidden = absent.filter((it) => it.visibleOnDesktop === false);
        if (hidden.length) {
          console.log(
            `    of those, ${hidden.length} are hidden on the desktop and need an owner-signed exclusion ` +
              `rather than an implementation: ${hidden.map((it) => `${it.tab}/${it.menu}`).join(', ')}`,
          );
        }
      }
      process.exit(1);
    }
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
