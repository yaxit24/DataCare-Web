#!/usr/bin/env node
/**
 * Schema readiness gate.
 *
 * WHAT IT CHECKS
 * --------------
 * `MS_UPDATE` has six buttons whose entire job is to CREATE or ALTER tables at runtime — SQL Server DDL fired
 * from the UI. The web owns schema through migrations and must not run DDL on a button press, so the faithful
 * translation of those buttons is a READINESS CHECK: assert that every table and column the desktop's
 * initialiser declares actually exists.
 *
 * WHY IT IS NOT A FORMALITY
 * -------------------------
 * The first run found a live defect. `DG_GOLD_MAST.BANK_AC_CODE` is declared by the desktop
 * (`ALTER TABLE DG_GOLD_MAST ADD BANK_AC_CODE VARCHAR(10) NOT NULL DEFAULT '00075'`) and bound to
 * `MS_GOLD_MAST`'s `tBankCode` control, and the web's gold-rate master DID render a "Bank A/c" field for it —
 * but the column was never migrated, so every save failed with
 * `column "BANK_AC_CODE" of relation "DG_GOLD_MAST" does not exist`. The form offered an input that could not
 * be saved, and nothing else would have caught it.
 *
 * HOW THE DENOMINATOR IS SET
 * --------------------------
 * From the desktop source, via `project-memory/parity/desktop_init_schema.py`, never from the web's own
 * schema. A gate that derives its expectations from the thing it is checking proves nothing.
 *
 * Columns still absent are listed in `parity/schema-readiness-baseline.json` with a reason. The gate fails
 * when something absent is NOT in the baseline (a regression) or when a baselined column now exists but has
 * not been removed from the baseline (so the list cannot rot).
 */

import { readFileSync } from 'node:fs';
import { fileURLToPath } from 'node:url';
import path from 'node:path';
// `pg` is not a workspace dependency; the generated Prisma client is, so the gate queries through it. Reading
// the LIVE database rather than a generated snapshot means the gate cannot go stale relative to migrations.

const here = path.dirname(fileURLToPath(import.meta.url));
const repo = path.resolve(here, '..');
const CONTRACT = path.resolve(repo, '..', 'project-memory', 'parity', 'DESKTOP-INIT-SCHEMA.json');
const BASELINE = path.resolve(repo, 'parity', 'schema-readiness-baseline.json');

const url = process.env.MIGRATE_DATABASE_URL || process.env.DATABASE_URL;
if (!url) {
  console.error('SCHEMA_READINESS_SKIP no MIGRATE_DATABASE_URL/DATABASE_URL');
  process.exit(0);
}

const contract = JSON.parse(readFileSync(CONTRACT, 'utf8'));
const baseline = JSON.parse(readFileSync(BASELINE, 'utf8'));

// pnpm hoists nothing to the workspace root, so the client is resolved from the package that depends on it.
const { createRequire } = await import('node:module');
const req = createRequire(path.join(repo, 'packages', 'db', 'package.json'));
const { PrismaClient } = req('@prisma/client');
const prisma = new PrismaClient({ datasources: { db: { url } } });
const rows = await prisma.$queryRawUnsafe(
  `SELECT table_name, column_name FROM information_schema.columns WHERE table_schema='public'`,
);
await prisma.$disconnect();

const live = new Set(
  rows.map((r) => `${r.table_name.toUpperCase()}.${r.column_name.toUpperCase()}`),
);
const liveTables = new Set(rows.map((r) => r.table_name.toUpperCase()));

const missingTables = [];
const missingColumns = [];
let expectedTables = 0;
let expectedColumns = 0;

for (const [table, cols] of Object.entries(contract.tables)) {
  expectedTables += 1;
  if (!liveTables.has(table)) {
    missingTables.push(table);
    continue;
  }
  for (const col of cols) {
    expectedColumns += 1;
    if (!live.has(`${table}.${col}`)) missingColumns.push(`${table}.${col}`);
  }
}

const allowed = new Set(Object.keys(baseline.absentColumns ?? {}));
const unexpected = missingColumns.filter((k) => !allowed.has(k));
// A baselined column that now exists must be removed from the baseline, or the list silently rots and stops
// describing reality.
const staleBaseline = [...allowed].filter((k) => !missingColumns.includes(k));

const presentColumns = expectedColumns - missingColumns.length;
const pct = expectedColumns ? ((100 * presentColumns) / expectedColumns).toFixed(1) : '100.0';

if (missingTables.length) {
  console.error(`SCHEMA_READINESS_FAIL missing tables: ${missingTables.join(', ')}`);
}
if (unexpected.length) {
  console.error(
    `SCHEMA_READINESS_FAIL ${unexpected.length} column(s) absent and not baselined:\n  ${unexpected.join('\n  ')}`,
  );
}
if (staleBaseline.length) {
  console.error(
    `SCHEMA_READINESS_FAIL baseline lists ${staleBaseline.length} column(s) that now exist; remove them:\n  ${staleBaseline.join('\n  ')}`,
  );
}
if (missingTables.length || unexpected.length || staleBaseline.length) process.exit(1);

console.log(
  `SCHEMA_READINESS_OK tables ${expectedTables}/${expectedTables}, ` +
    `columns ${presentColumns}/${expectedColumns} (${pct}%), ${missingColumns.length} baselined absent`,
);
