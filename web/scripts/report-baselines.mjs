#!/usr/bin/env node
/**
 * Report layout baselines (Phase G).
 *
 * Renders every high-severity Crystal spec through the real layout engine with a DETERMINISTIC
 * binding and records a checksum of the produced HTML plus its geometry counts. The HTML carries the
 * absolute positions extracted from the Crystal geometry, so a checksum over it detects layout drift
 * from either an engine change or a spec change.
 *
 * What this proves: the layout renders, binds and positions reproducibly, and nothing silently
 * changes it. What it does NOT prove: pixel equality with desktop output — that needs the desktop
 * runtime and belongs to G5. The distinction is recorded in the artifact itself.
 *
 *   node scripts/report-baselines.mjs            # verify against the retained baseline
 *   node scripts/report-baselines.mjs --write     # (re)generate after an intentional change
 */
import { createHash } from 'node:crypto';
import { readFileSync, readdirSync, writeFileSync, existsSync } from 'node:fs';
import { join, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';

const HERE = dirname(fileURLToPath(import.meta.url));
const ROOT = join(HERE, '..', '..');
const SPECS = join(HERE, '..', 'apps', 'api', 'report-specs');
const BASELINE = join(ROOT, 'project-memory', 'parity', 'REPORT-BASELINES.json');

const { renderReportLayout } = await import(
  join(HERE, '..', 'apps', 'api', 'dist', 'modules', 'reports', 'reportEngine.js')
).catch(async () => {
  throw new Error(
    'compiled engine not found — run `pnpm --filter @datacare/api build` before generating baselines',
  );
});

/**
 * Every usable spec is baselined, not just the high-severity list: the plan's 22 high-severity
 * documents are almost entirely the .rpt files that were never supplied (20 recorded as evidence
 * gaps, plus TagStkIdtlRpt), so a list-based baseline would cover one report. Baselining the whole
 * extracted surface is both cheaper and stronger — any engine or spec change shows up immediately.
 */
const REPORTS = readdirSync(SPECS)
  .filter((f) => f.endsWith('.spec.json'))
  .map((f) => f.slice(0, -'.spec.json'.length))
  .sort();

const FIELD = /\{([^}]+)\}/g;

/** Deterministic binding: every database field resolves to a stable marker derived from its own name,
 * so the checksum exercises the binding path without inventing business data. */
function bindingFor(spec) {
  const tokens = new Set();
  const text = JSON.stringify(spec);
  let m;
  while ((m = FIELD.exec(text))) {
    const key = m[1];
    if (key && !key.startsWith('@')) tokens.add(key);
  }
  const header = {};
  for (const token of [...tokens].sort()) header[token] = `V:${token}`;
  // Two detail rows so repeating sections render more than once.
  const detailRows = [
    header,
    Object.fromEntries(Object.entries(header).map(([k, v]) => [k, `${v}#2`])),
  ];
  return { header, detailRows, company: 'BASELINE CO' };
}

function measure(name) {
  const path = join(SPECS, `${name}.spec.json`);
  if (!existsSync(path)) return { report: name, status: 'spec-absent' };
  const spec = JSON.parse(readFileSync(path, 'utf8'));
  if (!Array.isArray(spec.areas)) return { report: name, status: 'spec-unusable' };
  const objects = spec.areas.reduce(
    (n, a) => n + (a.sections || []).reduce((k, s) => k + (s.objects || []).length, 0),
    0,
  );
  const sections = spec.areas.reduce((n, a) => n + (a.sections || []).length, 0);
  const html = renderReportLayout(spec, bindingFor(spec));
  return {
    report: name,
    status: 'rendered',
    areas: spec.areas.length,
    sections,
    objects,
    htmlBytes: html.length,
    sha256: createHash('sha256').update(html).digest('hex'),
  };
}

const results = REPORTS.map(measure);
const artifact = {
  generatedAt: new Date().toISOString().slice(0, 10),
  proves:
    'Each high-severity Crystal layout renders, binds and positions reproducibly; any engine or spec change alters the checksum.',
  doesNotProve:
    'Pixel equality with desktop output. That requires the desktop runtime and is tracked as G5.',
  reports: results,
};

const write = process.argv.includes('--write');
if (write) {
  writeFileSync(BASELINE, `${JSON.stringify(artifact, null, 2)}\n`);
  const rendered = results.filter((r) => r.status === 'rendered').length;
  console.log(`REPORT_BASELINES_WRITTEN ${rendered}/${results.length} rendered -> ${BASELINE}`);
} else {
  if (!existsSync(BASELINE)) {
    console.error('no baseline retained; run with --write');
    process.exit(1);
  }
  const prior = JSON.parse(readFileSync(BASELINE, 'utf8'));
  const before = new Map(prior.reports.map((r) => [r.report, r]));
  const drift = results.filter((r) => {
    const b = before.get(r.report);
    return !b || b.sha256 !== r.sha256 || b.status !== r.status;
  });
  if (drift.length) {
    console.error(
      `REPORT_BASELINE_DRIFT ${drift.length}: ${drift.map((d) => d.report).join(', ')}`,
    );
    process.exit(1);
  }
  console.log(`REPORT_BASELINES_OK ${results.length} layouts unchanged`);
}
