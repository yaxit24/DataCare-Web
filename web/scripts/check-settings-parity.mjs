#!/usr/bin/env node
/**
 * settings-exposure parity gate.
 *
 * Divides by a denominator derived from `information_schema` (via `settingsInventory.ts`), never from the
 * display catalog. That separation is the whole point: the previous surface exposed 55 curated CO_SET keys
 * and could not reach CO_SET_NEW at all, yet a catalog-derived measure would have called itself complete.
 * This is the same denominator error that produced the earlier "100% UI field capturability" claim.
 *
 * Fails when:
 *   - the schema denominator drifts from the pinned 130,
 *   - any configurable column has no catalog descriptor,
 *   - a descriptor is duplicated, or a boolean/enum descriptor has no options,
 *   - a descriptor claims a finite option list while marked unknownOptions,
 *   - the unknown-options count RISES above the recorded baseline (it may only fall).
 *
 * Usage: node scripts/check-settings-parity.mjs [--write]
 */
import { readFileSync, writeFileSync, existsSync } from 'node:fs';
import { fileURLToPath } from 'node:url';
import { dirname, resolve } from 'node:path';

const here = dirname(fileURLToPath(import.meta.url));
const root = resolve(here, '..');
const BASELINE = resolve(root, 'parity/settings-baseline.json');

const mod = async (p) => import(resolve(root, p));

const { SETTING_COLUMN_COUNTS, CONFIGURABLE_SETTINGS } = await mod(
  'apps/api/dist/modules/settings/settingsInventory.js',
);
const { SETTING_CATALOG } = await mod('apps/api/dist/modules/settings/settingsCatalog.js');

const problems = [];
const push = (m) => problems.push(m);

// 1. The denominator is fixed by the schema, not by us.
if (SETTING_COLUMN_COUNTS.CO_SET !== 60)
  push(`CO_SET columns ${SETTING_COLUMN_COUNTS.CO_SET} != 60`);
if (SETTING_COLUMN_COUNTS.CO_SET_NEW !== 70)
  push(`CO_SET_NEW columns ${SETTING_COLUMN_COUNTS.CO_SET_NEW} != 70`);
if (SETTING_COLUMN_COUNTS.total !== 130)
  push(`total settings ${SETTING_COLUMN_COUNTS.total} != 130`);

// 2. Every configurable column must have exactly one descriptor, identified by table+column.
const ids = SETTING_CATALOG.map((d) => d.id);
const dupes = ids.filter((v, i) => ids.indexOf(v) !== i);
if (dupes.length) push(`duplicate descriptors: ${[...new Set(dupes)].join(', ')}`);

const wanted = CONFIGURABLE_SETTINGS.map((c) => `${c.table}.${c.key}`);
const missing = wanted.filter((k) => !ids.includes(k));
if (missing.length) push(`no descriptor for: ${missing.join(', ')}`);

// 3. Structural integrity of each descriptor.
for (const d of SETTING_CATALOG) {
  if ((d.type === 'boolean' || d.type === 'enum') && !(d.options && d.options.length))
    push(`${d.id} is ${d.type} with no options`);
  if (d.unknownOptions && d.options)
    push(`${d.id} is marked unknownOptions but carries an option list`);
  if (d.unknownOptions && d.type !== 'text')
    push(`${d.id} is marked unknownOptions but typed ${d.type}`);
  for (const o of d.options ?? []) {
    if (!o.label || o.value === undefined) push(`${d.id} has a malformed option`);
  }
}

const exposure = {
  total: new Set(wanted).size,
  exposed: new Set(ids).size,
  unknownOptions: SETTING_CATALOG.filter((d) => d.unknownOptions).length,
  withOptions: SETTING_CATALOG.filter((d) => d.options?.length).length,
};
exposure.pct = Math.round((1000 * exposure.exposed) / exposure.total) / 10;

if (exposure.pct !== 100) push(`settings exposure ${exposure.pct}% (must be 100%)`);

// 4. Ratchet: unknown-options may fall, never rise.
if (process.argv.includes('--write')) {
  writeFileSync(BASELINE, JSON.stringify(exposure, null, 2) + '\n');
  console.log(`SETTINGS_BASELINE_WRITTEN ${JSON.stringify(exposure)}`);
  process.exit(0);
}
if (existsSync(BASELINE)) {
  const base = JSON.parse(readFileSync(BASELINE, 'utf8'));
  if (exposure.unknownOptions > base.unknownOptions)
    push(
      `unknown-options rose ${base.unknownOptions} -> ${exposure.unknownOptions}; a setting lost its evidence`,
    );
  if (exposure.exposed < base.exposed)
    push(`exposed settings fell ${base.exposed} -> ${exposure.exposed}`);
} else {
  push(`missing baseline ${BASELINE}; run with --write once`);
}

if (problems.length) {
  console.error('SETTINGS_PARITY_FAILED');
  for (const p of problems) console.error(`  - ${p}`);
  process.exit(1);
}
console.log(
  `SETTINGS_PARITY_OK ${exposure.exposed}/${exposure.total} (${exposure.pct}%) ` +
    `options=${exposure.withOptions} unknown=${exposure.unknownOptions}`,
);
