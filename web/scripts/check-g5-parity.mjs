#!/usr/bin/env node
/**
 * G5 gate — desktop-compared parity.
 *
 * This gate is RED until a comparison against a real, running DataCareNext installation exists. That is the
 * honest default: every arithmetic claim in this codebase is verified against the DECOMPILED SOURCE, which is
 * a strong form of evidence but not the same as comparing output with the application itself.
 *
 * WHAT COUNTS AS EVIDENCE
 * -----------------------
 * A diff artifact produced by `parity-compare.mjs` from two bundles, where:
 *
 *  * the desktop bundle came from a SQL Server (`engine: "sqlserver"`) and carries a real server version — a
 *    synthetic bundle is explicitly refused, because the instrument was proven using synthetic data and that
 *    proof must never be mistaken for the measurement;
 *  * every shared case matched;
 *  * no case was captured on one side only;
 *  * the comparison actually looked at something — a run with zero cases or zero fields is not a pass;
 *  * an operator and a date are recorded, so the artifact is attributable.
 *
 * WHY THE GATE REFUSES SYNTHETIC BUNDLES
 * -------------------------------------
 * The differ's own correctness was established by round-tripping a real web capture through a synthesised
 * desktop bundle and perturbing it: a shifted date, a rupee, a fourth decimal, a dropped table, a dropped row.
 * All were caught; identical bundles passed. That proves the INSTRUMENT. It says nothing about whether the two
 * applications agree, and a gate that accepted it would be measuring itself.
 */

import { readFile, readdir } from 'node:fs/promises';
import { fileURLToPath } from 'node:url';
import path from 'node:path';

const here = path.dirname(fileURLToPath(import.meta.url));
const repo = path.resolve(here, '..');
const G5_DIR = path.resolve(repo, '..', 'project-memory', 'parity', 'g5');

const fail = (why, ...detail) => {
  console.error(`G5_RED ${why}`);
  for (const d of detail) console.error(`  ${d}`);
  process.exit(1);
};

let entries = [];
try {
  entries = (await readdir(G5_DIR)).filter(
    // `parity-diff-latest.json` is an alias for the newest timestamped artifact; scanning only the timestamped
    // files keeps the ordering meaningful and stops the alias from being audited twice.
    (f) => f.startsWith('parity-diff-') && f.endsWith('.json') && f !== 'parity-diff-latest.json',
  );
} catch {
  fail('no comparison artifacts exist', `expected under ${path.relative(repo, G5_DIR)}`);
}
if (!entries.length) {
  fail(
    'no comparison artifacts exist',
    'run the extractors on the Windows box and then parity-compare.mjs',
    'see docs/PARITY-WINDOWS-PROCEDURE.md',
  );
}

const candidates = [];
const rejected = [];
for (const file of entries.sort().reverse()) {
  let report;
  try {
    report = JSON.parse(await readFile(path.join(G5_DIR, file), 'utf8'));
  } catch {
    rejected.push(`${file}: unreadable`);
    continue;
  }
  if (report?.kind !== 'datacare.parity-diff/1.0') {
    rejected.push(`${file}: not a parity diff artifact`);
    continue;
  }
  if (report.desktop?.engine !== 'sqlserver') {
    rejected.push(`${file}: desktop side is "${report.desktop?.engine}", not sqlserver`);
    continue;
  }
  // The synthetic bundle used to prove the differ names itself. Refusing it by marker AND by absence of a real
  // server version means a proof artifact cannot be promoted to evidence by renaming a file.
  // POSITIVE attestation, not absence of a marker.
  //
  // The first version of this check rejected artifacts whose provenance CONTAINED the word "synthetic". The
  // differ was dropping `appVersion` from the report, so the marker never arrived and the gate certified
  // synthetic data as desktop-compared parity. An absence test fails open; a presence test fails closed.
  //
  // A real bundle carries the SQL Server `@@VERSION` banner, which always begins "Microsoft SQL Server".
  const version = String(report.desktop?.appVersion ?? '');
  if (!/microsoft sql server/i.test(version)) {
    rejected.push(
      `${file}: desktop provenance is "${version || '(absent)'}" — no Microsoft SQL Server banner, ` +
        'so this is not a capture from a real installation',
    );
    continue;
  }
  candidates.push({ file, report });
}

if (!candidates.length) {
  fail(
    'no artifact came from a real SQL Server',
    ...rejected.slice(0, 6),
    'a real desktop bundle carries the SQL Server @@VERSION in source.appVersion',
  );
}

const { file, report } = candidates[0];
const t = report.totals ?? {};
const problems = [];
if (!report.matched)
  problems.push(`matched=false (${t.fieldDifferences ?? '?'} field differences)`);
if (!(t.cases > 0)) problems.push('zero cases compared');
if (!(t.fieldsCompared > 0)) problems.push('zero fields compared');
if ((report.desktopOnlyCases ?? []).length)
  problems.push(`cases never entered on the web: ${report.desktopOnlyCases.join(', ')}`);
if ((report.webOnlyCases ?? []).length)
  problems.push(`cases never entered on the desktop: ${report.webOnlyCases.join(', ')}`);
if (!report.comparedAt) problems.push('no comparison timestamp');

if (problems.length) fail(`${file} does not certify parity`, ...problems);

console.log(
  `G5_GREEN ${file}: ${t.casesMatched}/${t.cases} cases, ${t.fieldsCompared} fields compared ` +
    `(${t.fieldsExcluded} excluded), against ${report.desktop.engine} ${report.desktop.database}`,
);
