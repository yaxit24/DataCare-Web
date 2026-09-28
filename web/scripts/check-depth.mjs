#!/usr/bin/env node
/**
 * Operator-depth parity gate.
 *
 * WHY THIS EXISTS
 * `check-settings-parity.mjs` proves a setting is EXPOSED. `DEPTH-SCOREBOARD.md` proves a
 * column is WRITTEN. Neither proves an operator can reach the field or that the setting
 * changes an outcome — which is how a 34%-operator-depth application came to be recorded as
 * 98.9% complete. This gate measures the missing dimension and ratchets it.
 *
 * WHAT IT ENFORCES
 *   floors   (may only rise): web operator field surface, visible grid columns, settings
 *                             honoured in business logic, pages with grid keyboard
 *   ceilings (may only fall): API input fields unreachable from any screen, contained
 *                             (503-blocked) operations, inert settings
 *   phase    exit targets from depth-parity-baseline.json when --phase <id> is given
 *
 * The baseline is data, so it can be edited — that is unavoidable. What makes the ratchet
 * real is that `--phase` targets are declared UP FRONT for every phase, and `--audit`
 * re-derives every number from source, so a baseline edited to make a phase pass is visible
 * as a baseline diff in review rather than hidden in a passing build.
 *
 * Usage:
 *   node scripts/check-depth.mjs                 # ratchet only
 *   node scripts/check-depth.mjs --phase P1      # ratchet + phase P1 exit targets
 *   node scripts/check-depth.mjs --audit         # print full derivation, no pass/fail
 *   node scripts/check-depth.mjs --write         # (re)record the baseline; review the diff
 */
import { readFileSync, writeFileSync, existsSync } from 'node:fs';
import { execFileSync } from 'node:child_process';
import { fileURLToPath } from 'node:url';
import { dirname, resolve } from 'node:path';
import { measureUiDescriptors } from './lib/ui-descriptors.mjs';

const here = dirname(fileURLToPath(import.meta.url));
const root = resolve(here, '..');
const measureDir = resolve(root, '..', 'project-memory', 'parity');
const BASELINE = resolve(root, 'parity', 'depth-parity-baseline.json');

const argv = process.argv.slice(2);
const has = (f) => argv.includes(f);
const valueOf = (f) => {
  const i = argv.indexOf(f);
  return i >= 0 ? argv[i + 1] : undefined;
};

/** Run a measurement script and parse its JSON stdout. Fail loudly; never fall back to a guess. */
const measure = (script, args = []) => {
  try {
    const out = execFileSync('python3', [resolve(measureDir, script), ...args], {
      encoding: 'utf8',
      maxBuffer: 256 * 1024 * 1024,
    });
    return JSON.parse(out);
  } catch (e) {
    console.error(`FATAL: measurement ${script} failed to produce JSON.`);
    console.error(String(e?.stderr || e?.message || e));
    process.exit(2);
  }
};

// ---------------------------------------------------------------------------
// derive current state from source
// ---------------------------------------------------------------------------
const desktop = measure('richness_desktop.py', ['DataCareNext']);
const web = measure('richness_web.py');
const settings = measure('settings_parity.py');
const gaps = measure('gap_manifest.py');
const descriptors = measureUiDescriptors(root);

/** Contained operations are counted from the registry, not from a hand-kept list. */
const containedCount = (() => {
  const p = resolve(root, 'packages', 'core', 'containment.mjs');
  if (!existsSync(p)) return null;
  const src = readFileSync(p, 'utf8');
  const block = src.match(/parityContainmentOperations\s*=\s*Object\.freeze\(\[(.*?)\]\)/s);
  if (!block) return null;
  return (block[1].match(/'[^']+'/g) || []).length;
})();

/** Routes that actually refuse a mutation because of containment.
 *  The definition site reads `containMutation = (`, so it is not matched by `containMutation(`
 *  and must not be subtracted. Verified: 10 call sites, 0 false positives. */
const containedRoutes = (() => {
  const p = resolve(root, 'apps', 'api', 'src', 'routes', 'txn.ts');
  if (!existsSync(p)) return null;
  return (readFileSync(p, 'utf8').match(/containMutation\(/g) || []).length;
})();

/** Report workflows the web can actually run, counted from the authorization registry. */
const reportSlugs = (() => {
  const p = resolve(root, 'apps', 'api', 'src', 'modules', 'reports', 'reportAuthorization.ts');
  if (!existsSync(p)) return null;
  const src = readFileSync(p, 'utf8');
  const block = src.match(/REPORT_FORM_BY_SLUG[^{]*\{(.*?)\n\}/s);
  return block ? (block[1].match(/^\s*'[a-z0-9-]+':/gm) || []).length : null;
})();

const dt = desktop.totals;
const wt = web.totals;

const current = {
  descriptorSurface: {
    ...descriptors.totals,
    basis: descriptors.basis,
    limits: descriptors.limits,
    detailedAudit: 'node scripts/measure-ui-descriptors.mjs',
  },
  desktop: {
    forms: dt.forms,
    inputControls: dt.inputControls,
    gridNamedCols: dt.gridNamedCols,
    operatorSurface: dt.inputControls + dt.gridNamedCols,
    distinctValidationMessages: dt.distinctValidationMessages,
    gridCellEvents: dt.gridCellEvents,
  },
  web: {
    pages: wt.pages,
    txnPages: wt.txnPages,
    txnPagesWithLineGrid: wt.txnPagesWithLineGrid,
    txnPagesWithEditableGrid: wt.txnPagesWithEditableGrid,
    inputControls: wt.unionInputControls,
    gridColumns: wt.unionGridColumns,
    operatorSurface: wt.unionSurface,
    pagesWithGridKeyboard: wt.pagesWithGridKeyboard,
    txnPagesWithGridKeyboard: wt.txnPagesWithGridKeyboard,
    // The meaningful adoption measure: of the txn pages that actually HAVE a multi-row grid, how
    // many honour the keyboard contract. Measuring against all 66 txn pages would demand the hook
    // on header-only vouchers (daily rate, dhiran interest, ledger adjust) that have no rows to
    // navigate — a target satisfiable only by meaningless code.
    txnGridPagesWithKeyboard: wt.txnGridPagesWithKeyboard,
    txnEditableGridPagesWithKeyboard: wt.txnEditableGridPagesWithKeyboard,
    pagesWithLookupPicker: wt.pagesWithLookupPicker,
    pagesWithLineRecalc: wt.pagesWithLineRecalc,
    pagesWithSubDetailGrid: wt.pagesWithSubDetailGrid,
    apiValidationMessages: web.api.distinctValidationMessages,
  },
  ratios: {
    operatorSurfacePct: +((100 * wt.unionSurface) / (dt.inputControls + dt.gridNamedCols)).toFixed(
      1,
    ),
    gridColumnPct: +((100 * wt.unionGridColumns) / dt.gridNamedCols).toFixed(1),
    inputControlPct: +((100 * wt.unionInputControls) / dt.inputControls).toFixed(1),
    /**
     * Second basis, reported alongside because the two answer different questions and the gap
     * between them is large enough to mislead if only one is shown.
     *
     *   union    distinct field surface BUILT   — a shared component counts once
     *   perPage  field surface an operator REACHES — a shared component counts on every page
     *
     * Desktop's 5,107 is itself a per-form sum with no de-duplication, so perPage is the true
     * like-for-like comparison and reads higher. The union stays the headline and the ratchet floor
     * regardless, because it is the conservative one and it is what the published gap report used.
     * Switching basis mid-flight would book a measurement change as progress; progress is only ever
     * claimed against the basis a number was baselined on.
     */
    operatorSurfacePerPagePct: +(
      (100 * (wt.pageSumInputControls + wt.pageSumGridColumns)) /
      (dt.inputControls + dt.gridNamedCols)
    ).toFixed(1),
  },
  settings: {
    inventory: settings.web.inventoryTotal,
    honoured: settings.web.honouredInBusinessLogic,
    inert: settings.web.storedOrDisplayedOnly,
  },
  reachability: {
    apiInputFields: gaps.totals.inputFields,
    reachableFromUi: gaps.totals.reachableFromUi,
    apiOnlyUnreachable: gaps.totals.apiOnlyUnreachable,
  },
  containment: { operations: containedCount, blockedRoutes: containedRoutes },
  reports: { runnableSlugs: reportSlugs },
};

if (has('--audit')) {
  console.log(JSON.stringify(current, null, 1));
  process.exit(0);
}

if (has('--write') || !existsSync(BASELINE)) {
  const phases = existsSync(BASELINE) ? JSON.parse(readFileSync(BASELINE, 'utf8')).phases : {};
  writeFileSync(
    BASELINE,
    `${JSON.stringify({ recordedAt: new Date().toISOString(), current, phases }, null, 1)}\n`,
  );
  console.log(`depth baseline written to ${BASELINE}`);
  console.log(
    'Review the diff: a loosened floor or raised ceiling is a regression being accepted.',
  );
  process.exit(0);
}

const base = JSON.parse(readFileSync(BASELINE, 'utf8'));
const problems = [];
const wins = [];

/** A floor may only rise. Falling means the web lost operator depth. */
const floor = (path, label) => {
  const b = path.split('.').reduce((o, k) => o?.[k], base.current);
  const c = path.split('.').reduce((o, k) => o?.[k], current);
  if (b == null || c == null) return;
  if (c < b) problems.push(`FLOOR BREACHED  ${label}: ${b} -> ${c} (depth lost)`);
  else if (c > b) wins.push(`${label}: ${b} -> ${c} (+${+(c - b).toFixed(1)})`);
};

/** A ceiling may only fall. Rising means more capability became unreachable or blocked. */
const ceiling = (path, label) => {
  const b = path.split('.').reduce((o, k) => o?.[k], base.current);
  const c = path.split('.').reduce((o, k) => o?.[k], current);
  if (b == null || c == null) return;
  if (c > b) problems.push(`CEILING BREACHED  ${label}: ${b} -> ${c} (regression)`);
  else if (c < b) wins.push(`${label}: ${b} -> ${c} (-${+(b - c).toFixed(1)})`);
};

floor('web.operatorSurface', 'web operator field surface');
floor('web.gridColumns', 'web visible grid columns');
floor('web.inputControls', 'web input controls');
floor('web.pagesWithGridKeyboard', 'pages with grid keyboard');
floor('web.txnPagesWithGridKeyboard', 'txn pages with grid keyboard');
floor('web.txnPagesWithLineGrid', 'txn pages presenting a line grid');
floor('web.txnGridPagesWithKeyboard', 'txn grid pages honouring the keyboard contract');
floor('web.txnPagesWithEditableGrid', 'txn pages with an operator-authored grid');
floor('web.txnEditableGridPagesWithKeyboard', 'authored grids honouring the keyboard contract');
floor('web.pagesWithLineRecalc', 'pages using the recalculation kernel');
floor('web.pagesWithSubDetailGrid', 'pages rendering a sub-detail grid');
floor('web.apiValidationMessages', 'enforced validation messages');
floor('reports.runnableSlugs', 'runnable report workflows');
floor('ratios.operatorSurfacePct', 'operator surface % of desktop');
floor('ratios.gridColumnPct', 'grid column % of desktop');
floor('settings.honoured', 'settings honoured in business logic');
floor('reachability.reachableFromUi', 'API fields reachable from a screen');

ceiling('settings.inert', 'inert settings');
ceiling('reachability.apiOnlyUnreachable', 'API fields no screen can supply');
ceiling('containment.operations', 'contained operations');
ceiling('containment.blockedRoutes', 'containment-blocked routes');

// The desktop side is ground truth; if it moves, the extractor or the source changed and every
// ratio in the plan is invalid until re-derived.
for (const [k, v] of Object.entries(base.current.desktop)) {
  if (current.desktop[k] !== v)
    problems.push(
      `DESKTOP BASELINE MOVED  ${k}: ${v} -> ${current.desktop[k]}. Ground truth changed; re-derive the plan's ratios before trusting any target.`,
    );
}

// ---------------------------------------------------------------------------
// phase exit targets
// ---------------------------------------------------------------------------
const phaseId = valueOf('--phase');
if (phaseId) {
  const phase = base.phases?.[phaseId];
  if (!phase) {
    console.error(`FATAL: no exit targets declared for phase ${phaseId} in ${BASELINE}.`);
    console.error('A phase without declared targets cannot be certified complete.');
    process.exit(2);
  }
  for (const [path, target] of Object.entries(phase.targets || {})) {
    const c = path.split('.').reduce((o, k) => o?.[k], current);
    const cmp = phase.direction?.[path] ?? 'atLeast';
    const ok = cmp === 'atMost' ? c <= target : c >= target;
    if (!ok)
      problems.push(
        `PHASE ${phaseId} TARGET MISSED  ${path}: ${c} (needs ${cmp === 'atMost' ? '<=' : '>='} ${target})`,
      );
    else
      wins.push(
        `phase ${phaseId} ${path} = ${c} (target ${cmp === 'atMost' ? '<=' : '>='} ${target})`,
      );
  }
}

// ---------------------------------------------------------------------------
console.log('operator-depth parity');
console.log(
  `  surface ${current.web.operatorSurface}/${current.desktop.operatorSurface} = ${current.ratios.operatorSurfacePct}%   ` +
    `grid cols ${current.web.gridColumns}/${current.desktop.gridNamedCols} = ${current.ratios.gridColumnPct}%`,
);
console.log(
  `  settings honoured ${current.settings.honoured}/${current.settings.inventory} (inert ${current.settings.inert})   ` +
    `unreachable API fields ${current.reachability.apiOnlyUnreachable}   contained ops ${current.containment.operations}`,
);
if (wins.length) {
  console.log('\nimprovements since baseline:');
  for (const w of wins) console.log(`  + ${w}`);
}
if (problems.length) {
  console.error('\nDEPTH GATE FAILED');
  for (const p of problems) console.error(`  - ${p}`);
  process.exit(1);
}
console.log(`\ndepth gate passed${phaseId ? ` (phase ${phaseId} targets met)` : ''}.`);
process.exit(0);
