#!/usr/bin/env node
/**
 * Column TYPE parity between the desktop schema and the web's Postgres schema.
 *
 * WHY THIS EXISTS
 * `check-schema-readiness.mjs` reports 145/145 tables and 5231/5231 columns at 100%, and that number is
 * true — but it measures column PRESENCE ONLY. The contract it reads
 * (`project-memory/parity/DESKTOP-REAL-SCHEMA.json`) is a list of column NAMES per table with no type
 * information at all, so the gate has never compared a single type. It cannot.
 *
 * Measured against the real customer database, 226 of 5231 shared columns (4.3%) are NUMERIC on the desktop
 * and TEXT in the web's Postgres schema. The direction is entirely one-way — 226 desktop-numeric to web-text,
 * zero the other way — which is what makes it a systematic migration defect rather than a deliberate choice.
 *
 * This was found by replaying a real voucher: the comparison flagged `SL_DATA.ADV_AMT` as
 * `desktop=0.000000 web=0`, which looked like a differ artifact and was briefly written up as one. It is not.
 * The desktop column is `float`, the web column is `character varying`, and the two canonicalise differently
 * because they genuinely are different types.
 *
 * WHY IT MATTERS
 *   * `SUM`/`AVG` over a text column need an explicit cast, and a cast that meets a non-numeric string
 *     throws at query time rather than at write time.
 *   * `ORDER BY` is lexicographic, so '9' sorts after '10' — a report ordered by amount orders wrongly.
 *   * Nothing prevents a non-numeric string being stored, so the column carries no domain guarantee.
 *
 * `closingStock.ts` already carries a `VAL()` regex cast for `BAL_GR`, and that was documented as mirroring
 * the desktop. It is not mirroring anything: the desktop's `BAL_GR.AVG_FINE` is `float`. The cast is
 * compensating for this defect.
 *
 * HOW IT BEHAVES
 * The 226 known mismatches are baselined, because fixing them is a migration exercise with a data-conversion
 * step and cannot be a precondition for every commit. What this gate prevents is a NEW one appearing, and it
 * reports the baseline count every run so it stays visible rather than becoming invisible debt.
 *
 * Usage:
 *   MSSQL_TYPES=/tmp/mssqltypes.txt DATABASE_URL=postgres://... node scripts/check-type-parity.mjs
 *
 * The desktop side needs a types dump, which requires the SQL Server container. Produce it with:
 *   SELECT UPPER(t.name)+'|'+UPPER(c.name)+'|'+LOWER(ty.name)
 *     FROM sys.tables t JOIN sys.columns c ON c.object_id=t.object_id
 *                       JOIN sys.types  ty ON ty.user_type_id=c.user_type_id
 * When the dump is absent the gate reports TYPE_PARITY_SKIP rather than passing, so an unavailable
 * measurement can never read as a clean one.
 */
import { readFile, writeFile } from 'node:fs/promises';
import path from 'node:path';
import process from 'node:process';
import { fileURLToPath } from 'node:url';

const here = path.dirname(fileURLToPath(import.meta.url));
const repo = path.resolve(here, '..');
const BASELINE = path.resolve(repo, 'scripts', 'type-parity-baseline.json');

const NUMERIC = new Set([
  'bigint',
  'decimal',
  'double precision',
  'float',
  'int',
  'integer',
  'money',
  'numeric',
  'real',
  'smallint',
  'smallmoney',
  'tinyint',
]);

const isNum = (t) => NUMERIC.has(String(t).toLowerCase());

function parseDump(text) {
  const out = new Map();
  for (const line of text.split('\n')) {
    const p = line.trim().split('|');
    if (p.length === 3 && p[0] && p[1]) out.set(`${p[0]}.${p[1]}`, p[2].toLowerCase());
  }
  return out;
}

async function main() {
  const dumpPath = process.env.MSSQL_TYPES;
  if (!dumpPath) {
    console.log('TYPE_PARITY_SKIP no MSSQL_TYPES dump supplied');
    console.log('  this is a SKIP, not a pass: the comparison was not performed');
    process.exit(0);
  }
  let desktop;
  try {
    desktop = parseDump(await readFile(dumpPath, 'utf8'));
  } catch (e) {
    console.log(`TYPE_PARITY_SKIP cannot read ${dumpPath}: ${e.message}`);
    process.exit(0);
  }

  const url = process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL;
  if (!url) {
    console.log('TYPE_PARITY_SKIP no DATABASE_URL');
    process.exit(0);
  }
  // Resolve from packages/db, the way the sibling gates do - a bare import fails from scripts/.
  const { createRequire } = await import('node:module');
  const req = createRequire(path.join(repo, 'packages', 'db', 'package.json'));
  const { PrismaClient } = req('@prisma/client');
  const prisma = new PrismaClient({ datasources: { db: { url: url.split('?')[0] } } });
  const rows = await prisma.$queryRawUnsafe(
    `SELECT upper(table_name) t, upper(column_name) c, data_type d
       FROM information_schema.columns WHERE table_schema='public'`,
  );
  await prisma.$disconnect();
  const web = new Map(rows.map((r) => [`${r.t}.${r.c}`, String(r.d).toLowerCase()]));

  const mismatches = [];
  for (const [key, dType] of desktop) {
    const wType = web.get(key);
    if (!wType) continue; // absence is check-schema-readiness's job, not this gate's
    if (isNum(dType) !== isNum(wType)) mismatches.push({ column: key, desktop: dType, web: wType });
  }
  mismatches.sort((a, b) => a.column.localeCompare(b.column));

  let baseline = { columns: [] };
  try {
    baseline = JSON.parse(await readFile(BASELINE, 'utf8'));
  } catch {
    /* first run writes it */
  }
  const known = new Set(baseline.columns ?? []);
  const fresh = mismatches.filter((m) => !known.has(m.column));
  const fixed = [...known].filter((k) => !mismatches.some((m) => m.column === k));

  const shared = [...desktop.keys()].filter((k) => web.has(k)).length;
  console.log(
    `type parity: ${shared} shared columns, ${mismatches.length} numeric/text mismatch(es), ${known.size} baselined`,
  );

  if (process.argv.includes('--write')) {
    await writeFile(
      BASELINE,
      `${JSON.stringify(
        {
          note: 'Columns numeric on the desktop and text in Postgres. Baselined so a NEW one fails; fixing these is a migration with a data-conversion step.',
          measuredAgainst: 'Live24, the real customer database',
          count: mismatches.length,
          columns: mismatches.map((m) => m.column),
        },
        null,
        2,
      )}\n`,
    );
    console.log(`  baseline written: ${mismatches.length} column(s)`);
    return;
  }

  if (fixed.length) {
    console.log(
      `  ${fixed.length} baselined column(s) now agree — rerun with --write to shrink it:`,
    );
    for (const c of fixed.slice(0, 10)) console.log(`    ${c}`);
  }
  if (fresh.length) {
    console.log(`TYPE_PARITY_RED ${fresh.length} NEW numeric/text mismatch(es)`);
    for (const m of fresh.slice(0, 20)) {
      console.log(`    ${m.column}: desktop ${m.desktop} -> web ${m.web}`);
    }
    process.exit(1);
  }
  console.log('TYPE_PARITY_OK no new mismatches');
  if (mismatches.length) {
    console.log(
      `  ${mismatches.length} known mismatch(es) remain — see ${path.basename(BASELINE)}`,
    );
  }
}

main().catch((e) => {
  console.error('TYPE_PARITY_FAIL', e?.message ?? e);
  process.exit(1);
});
