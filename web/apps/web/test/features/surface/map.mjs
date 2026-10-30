import { readFileSync, writeFileSync } from 'node:fs';
import { resolve } from 'node:path';
import { webRoot } from '../harness.mjs';
import { catalogByRoute, deepCoverage } from './crawl.mjs';

const repoRoot = resolve(webRoot, '..');
const baselinePath = resolve(webRoot, 'apps/web/test/features/surface-baseline.json');

/** A stable identity for a finding, so the baseline survives timing noise in details. */
export const findingKey = (f) =>
  [
    f.route,
    f.kind,
    f.probe ?? '',
    String(f.button ?? '').replace(/\s*\(\d+\)$/, ' (n)'),
    f.kind === 'server-error' || f.kind === 'load-refused'
      ? String(f.detail)
          .replace(/\?.*$/, '')
          .replace(/→ \d+$/, '')
      : '',
  ].join(' | ');

function verdictOf(all) {
  const findings = all.filter((f) => !f.byDesign);
  if (findings.some((f) => f.severity === 'high')) return 'BROKEN';
  if (findings.some((f) => f.kind === 'placeholder')) return 'PLACEHOLDER';
  if (findings.some((f) => f.severity === 'medium')) return 'DEFECTS';
  return 'WORKS';
}

/** Join crawl records into one row per route. */
export function buildMap({ meta, records, out, writeDoc }) {
  const { byRoute: catalog } = catalogByRoute();
  const deep = deepCoverage();
  const byRoute = new Map();
  for (const record of records) {
    const row = byRoute.get(record.route) ?? {
      route: record.route,
      label: record.label,
      group: record.group,
      inMenu: record.inMenu,
      aliases: record.aliases,
      desktop: catalog.get(record.route) ?? [],
      deepTests: [...(deep.get(record.route) ?? [])],
      heading: '',
      controls: null,
      apiOnLoad: [],
      probes: [],
      buttons: [],
      findings: [],
    };
    if (record.phase === 'safe') {
      row.heading = record.structure?.heading ?? '';
      row.finalPath = record.finalPath;
      row.loadMs = record.loadMs;
      row.reportRows = record.reportRows;
      row.controls = record.structure
        ? {
            buttons: record.structure.buttons?.length ?? 0,
            inputs: record.structure.inputs ?? 0,
            selects: record.structure.selects?.length ?? 0,
            tables: record.structure.tables ?? 0,
            disclosures: record.disclosures ?? 0,
            buttonNames: [...new Set((record.structure.buttons ?? []).map((b) => b.name))],
          }
        : null;
      row.apiOnLoad = (record.loadRequests ?? []).map((r) => `${r.method} ${r.path} ${r.status}`);
    }
    row.probes.push(
      ...(record.probes ?? []).map((p) => ({
        probe: p.probe,
        kinds: p.effect.kinds,
        feedback: p.effect.feedback,
        requests: p.effect.requests.map((r) => `${r.method} ${r.path} ${r.status}`),
      })),
    );
    row.buttons.push(...(record.buttons ?? []).map((b) => ({ ...b, phase: record.phase })));
    row.findings.push(
      ...record.findings.map((f) => ({
        ...f,
        mode: f.probe || (f.phase === 'safe' && !f.button) ? 'probe' : 'sweep',
      })),
    );
    byRoute.set(record.route, row);
  }
  const rows = [...byRoute.values()];
  const byDesign = new Map(
    (JSON.parse(readFileSync(baselinePath, 'utf8')).byDesign ?? []).map((e) => [e.key, e.source]),
  );
  for (const row of rows) {
    const keys = new Set();
    row.findings = row.findings.filter((f) => {
      const k = findingKey(f);
      if (keys.has(k)) return false;
      keys.add(k);
      return true;
    });
    for (const f of row.findings)
      if (byDesign.has(findingKey(f))) f.byDesign = byDesign.get(findingKey(f));
    row.verdict = verdictOf(row.findings);
    const effects = row.buttons.map((b) => b.kinds?.join('+') ?? '');
    row.buttonSummary = {
      pressed: row.buttons.length,
      withEffect: effects.filter(
        (e) => e && !/^(none|disabled|hidden|not-present-after-reload)$/.test(e),
      ).length,
      noEffect: effects.filter((e) => e === 'none').length,
      disabledOrHidden: effects.filter((e) => /^(disabled|hidden)$/.test(e)).length,
      erroring: row.buttons.filter((b) => (b.requests ?? []).some((r) => r.status >= 500)).length,
    };
  }
  const count = (list, key) =>
    list.reduce((acc, x) => ((acc[key(x)] = (acc[key(x)] ?? 0) + 1), acc), {});
  const allFindings = rows.flatMap((r) => r.findings);
  const map = {
    meta,
    summary: {
      routes: rows.length,
      verdicts: count(rows, (r) => r.verdict),
      findingsBySeverity: count(allFindings, (f) => f.severity),
      findingsByKind: count(allFindings, (f) => f.kind),
      buttonsPressed: rows.reduce((s, r) => s + r.buttonSummary.pressed, 0),
      deepTestedRoutes: rows.filter((r) => r.deepTests.length).length,
    },
    rows,
  };
  writeFileSync(resolve(out, 'map.json'), `${JSON.stringify(map, null, 2)}\n`);
  const markdown = renderMarkdown(map);
  writeFileSync(resolve(out, 'map.md'), markdown);
  if (writeDoc) writeFileSync(resolve(repoRoot, 'docs/handbook/web/ui-surface-map.md'), markdown);
  return map;
}

const cell = (s) =>
  String(s ?? '')
    .replace(/\|/g, '\\|')
    .replace(/\n/g, ' ');

function renderMarkdown(map) {
  const { meta, summary, rows } = map;
  const lines = [];
  lines.push('# Web UI surface map');
  lines.push('');
  lines.push(
    'Generated by `web/apps/web/test/features/run-surface.mjs` (testing handbook §4b) from a logged-in crawl of the disposable stack. Do not edit by hand; rerun with `SURFACE_SWEEP=1 SURFACE_WRITE_DOC=1`.',
  );
  lines.push('');
  lines.push(
    `Candidate \`${meta.candidate}\`${meta.dirtyPatch ? ' (with local changes)' : ''}, ${meta.finishedAt}, every button pressed: ${meta.sweep ? 'yes' : 'no (probes only)'}, ${meta.durationSeconds}s.`,
  );
  lines.push('');
  lines.push(
    meta.label === 'with-data'
      ? 'Data: crawled after the feature suites created real vouchers through the screens (sales, purchases, settings changes), so registers, ledgers and Load have data to act on.'
      : 'Data: crawled on a company with masters only (no vouchers); reports and Load had nothing to show.',
  );
  lines.push('');
  lines.push(
    '**What a verdict means.** `WORKS` = the page rendered, its load requests succeeded and every probe/button behaved (no crash, no server error, refusals visible). It does **not** mean desktop parity: that is the `Desktop` column (menu catalog status) and the `Deep tests` column (journeys / feature modules that prove the lifecycle). `DEFECTS` = medium findings. `BROKEN` = a crash, server error, lost session or failed load. `PLACEHOLDER` = the planned-screen placeholder.',
  );
  lines.push('');
  lines.push('## Summary');
  lines.push('');
  lines.push(
    `| Routes | ${Object.keys(summary.verdicts)
      .map((v) => v)
      .join(' | ')} | Buttons pressed | Deep-tested routes |`,
  );
  lines.push(
    `|---|${Object.keys(summary.verdicts)
      .map(() => '---')
      .join('|')}|---|---|`,
  );
  lines.push(
    `| ${summary.routes} | ${Object.values(summary.verdicts).join(' | ')} | ${summary.buttonsPressed} | ${summary.deepTestedRoutes} |`,
  );
  lines.push('');
  lines.push(
    'Findings by kind: ' +
      Object.entries(summary.findingsByKind)
        .map(([k, v]) => `\`${k}\` ${v}`)
        .join(', ') +
      '.',
  );
  lines.push('');
  const groups = [...new Set(rows.map((r) => r.group))];
  for (const group of groups) {
    lines.push(`## ${group}`);
    lines.push('');
    lines.push(
      '| Route | Menu | Desktop (catalog) | Verdict | Controls b/i/s/t | Buttons effect/none/total | Deep tests | Findings |',
    );
    lines.push('|---|---|---|---|---|---|---|---|');
    for (const r of rows.filter((x) => x.group === group)) {
      const desktop = r.desktop.length
        ? r.desktop.map((d) => `${d.forms.join('+')} ${d.status}`).join('; ')
        : '—';
      const controls = r.controls
        ? `${r.controls.buttons}/${r.controls.inputs}/${r.controls.selects}/${r.controls.tables}`
        : '—';
      const buttons = `${r.buttonSummary.withEffect}/${r.buttonSummary.noEffect}/${r.buttonSummary.pressed}`;
      const findings = r.findings
        .filter((f) => f.severity !== 'low')
        .map(
          (f) =>
            `${f.byDesign ? 'by design' : f.severity} ${f.kind}${f.button ? ` [${f.button}]` : ''}: ${f.detail}`,
        )
        .slice(0, 4)
        .join('; ');
      const low = r.findings.filter((f) => f.severity === 'low').length;
      lines.push(
        `| \`${cell(r.route)}\` | ${cell(r.label)} | ${cell(desktop)} | ${r.verdict} | ${controls} | ${buttons} | ${r.deepTests.length ? r.deepTests.length : '—'} | ${cell(findings)}${low ? ` (+${low} low)` : ''} |`,
      );
    }
    lines.push('');
  }
  return `${lines.join('\n')}\n`;
}

/**
 * Shrink-only gate over medium/high findings. A probe-only run (CI) checks only probe findings; a full sweep checks
 * everything.
 */
export function gate(map, { sweep }) {
  const baseline = JSON.parse(readFileSync(baselinePath, 'utf8'));
  const known = new Map((baseline.findings ?? []).map((f) => [f.key, f]));
  const byDesign = new Map((baseline.byDesign ?? []).map((f) => [f.key, f]));
  const current = map.rows
    .flatMap((r) => r.findings)
    .filter((f) => f.severity !== 'low' && (sweep || f.mode === 'probe'));
  const currentKeys = new Set(current.map(findingKey));
  // A partial run (SURFACE_ROUTES) can only judge the routes it visited.
  const crawled = new Set(map.rows.map((r) => r.route));
  const inRun = (key) => crawled.has(key.split(' | ')[0]);
  const problems = [];
  for (const f of current) {
    const key = findingKey(f);
    if (!known.has(key) && !byDesign.has(key))
      problems.push(
        `NEW ${f.severity} ${f.kind} on ${f.route}${f.button ? ` [${f.button}]` : ''}: ${f.detail}`,
      );
  }
  for (const [key, entry] of byDesign) {
    if (!inRun(key) || (!sweep && entry.mode === 'sweep')) continue;
    if (!currentKeys.has(key))
      problems.push(`by-design entry no longer observed (remove it): ${key}`);
  }
  for (const [key, entry] of known) {
    if (!inRun(key) || (!sweep && entry.mode === 'sweep')) continue;
    if (!currentKeys.has(key)) problems.push(`FIXED (remove from surface-baseline.json): ${key}`);
  }
  return { checked: current.length, known: known.size, byDesign: byDesign.size, problems };
}
