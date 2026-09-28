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
 * Developer CI permits an explicitly reviewed baseline because fixing a mismatch is a migration exercise with
 * a data-conversion step. Release certification invokes `--release`, which requires that baseline debt to be
 * zero. Both modes first require the dump to contain the exact 5,231-column desktop schema contract: an empty,
 * truncated, duplicate or arbitrarily selected dump is a failure, never a zero-difference result.
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
import { createHash } from 'node:crypto';
import { readFile, writeFile } from 'node:fs/promises';
import path from 'node:path';
import process from 'node:process';
import { fileURLToPath } from 'node:url';

const here = path.dirname(fileURLToPath(import.meta.url));
const repo = path.resolve(here, '..');
const BASELINE = path.resolve(repo, 'scripts', 'type-parity-baseline.json');
const DESKTOP_SCHEMA = path.resolve(
  repo,
  '..',
  'project-memory',
  'parity',
  'DESKTOP-REAL-SCHEMA.json',
);

/**
 * Identity of the retained Live24 structure capture that defines the type-dump denominator.
 *
 * The capture itself is deliberately kept outside the product tree, but that must not let an arbitrary
 * 5,231-column replacement choose what the release gate compares. These values are candidate source, so the
 * required release commit binds them even when the capture is supplied separately on the release runner.
 */
export const FROZEN_DESKTOP_SCHEMA_IDENTITY = Object.freeze({
  tableCount: 145,
  columnCount: 5231,
  sha256: '547a424c5a8703c0904fafd87d6fd2125b8ee5c08c1189d1a12d73cf48cd3dac',
});

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

const isRecord = (value) => value !== null && typeof value === 'object' && !Array.isArray(value);

/** Parse the deliberately headerless TABLE|COLUMN|TYPE SQL Server export without discarding bad rows. */
export function parseTypeDump(text) {
  const columns = new Map();
  const malformedLines = [];
  const duplicateColumns = [];
  for (const [index, sourceLine] of String(text).split(/\r?\n/).entries()) {
    const line = sourceLine.trim();
    if (!line) continue;
    const parts = line.split('|').map((part) => part.trim());
    if (parts.length !== 3 || parts.some((part) => !part)) {
      malformedLines.push(index + 1);
      continue;
    }
    const key = `${parts[0].toUpperCase()}.${parts[1].toUpperCase()}`;
    if (columns.has(key)) {
      duplicateColumns.push(key);
      continue;
    }
    columns.set(key, parts[2].toLowerCase());
  }
  return { columns, malformedLines, duplicateColumns };
}

/** Turn the independently retained desktop structure into its exact TABLE.COLUMN denominator. */
export function desktopSchemaColumns(contract) {
  if (!isRecord(contract) || !isRecord(contract.tables)) {
    throw new Error('desktop schema contract has no tables object');
  }
  const tableEntries = Object.entries(contract.tables);
  if (!Number.isSafeInteger(contract.tableCount) || contract.tableCount !== tableEntries.length) {
    throw new Error('desktop schema contract tableCount does not match tables');
  }
  const columns = new Set();
  for (const [tableName, tableColumns] of tableEntries) {
    if (!tableName.trim() || !Array.isArray(tableColumns) || tableColumns.length === 0) {
      throw new Error(`desktop schema contract has invalid table ${tableName || '(blank)'}`);
    }
    for (const columnName of tableColumns) {
      if (typeof columnName !== 'string' || !columnName.trim()) {
        throw new Error(`desktop schema contract has an invalid column in ${tableName}`);
      }
      const key = `${tableName.toUpperCase()}.${columnName.toUpperCase()}`;
      if (columns.has(key)) throw new Error(`desktop schema contract duplicates ${key}`);
      columns.add(key);
    }
  }
  if (!Number.isSafeInteger(contract.columnCount) || contract.columnCount !== columns.size) {
    throw new Error('desktop schema contract columnCount does not match tables');
  }
  return columns;
}

/** Parse a desktop-schema capture only after its exact bytes and declared denominator are frozen. */
export function frozenDesktopSchemaColumns(source, identity = FROZEN_DESKTOP_SCHEMA_IDENTITY) {
  const bytes = Buffer.isBuffer(source) ? source : Buffer.from(String(source), 'utf8');
  const actualSha256 = createHash('sha256').update(bytes).digest('hex');
  if (actualSha256 !== identity.sha256) {
    throw new Error(
      `desktop schema contract SHA-256 ${actualSha256} does not match frozen identity ${identity.sha256}`,
    );
  }
  const contract = JSON.parse(bytes.toString('utf8'));
  const columns = desktopSchemaColumns(contract);
  if (contract.tableCount !== identity.tableCount || columns.size !== identity.columnCount) {
    throw new Error(
      `desktop schema contract denominator ${String(contract.tableCount)}/${columns.size} does not match ` +
        `frozen identity ${String(identity.tableCount)}/${String(identity.columnCount)}`,
    );
  }
  return columns;
}

/** Refuse any dump that gets to choose a smaller comparison denominator. */
export function typeDumpCoverageProblems(parsed, expectedColumns) {
  const problems = [];
  if (!(parsed?.columns instanceof Map)) return ['type dump parser produced no column map'];
  if (!(expectedColumns instanceof Set) || expectedColumns.size === 0) {
    return ['desktop schema contract has an empty column denominator'];
  }
  if (parsed.malformedLines.length) {
    problems.push(
      `malformed nonblank dump line(s): ${parsed.malformedLines.slice(0, 10).join(', ')}`,
    );
  }
  const duplicateColumns = [...new Set(parsed.duplicateColumns)].sort();
  if (duplicateColumns.length) {
    problems.push(`duplicate dump column(s): ${duplicateColumns.slice(0, 10).join(', ')}`);
  }
  const actualColumns = new Set(parsed.columns.keys());
  const missing = [...expectedColumns].filter((key) => !actualColumns.has(key)).sort();
  const unexpected = [...actualColumns].filter((key) => !expectedColumns.has(key)).sort();
  if (missing.length) {
    problems.push(
      `missing ${missing.length} desktop-schema column(s): ${missing.slice(0, 10).join(', ')}`,
    );
  }
  if (unexpected.length) {
    problems.push(
      `unexpected ${unexpected.length} dump column(s): ${unexpected.slice(0, 10).join(', ')}`,
    );
  }
  return problems;
}

async function main() {
  const dumpPath = process.env.MSSQL_TYPES;
  if (!dumpPath) {
    console.log('TYPE_PARITY_SKIP no MSSQL_TYPES dump supplied');
    console.log('  this is a SKIP, not a pass: the comparison was not performed');
    process.exit(0);
  }
  let dumpText;
  try {
    dumpText = await readFile(dumpPath, 'utf8');
  } catch (e) {
    console.log(`TYPE_PARITY_SKIP cannot read ${dumpPath}: ${e.message}`);
    process.exit(0);
  }

  let parsed;
  let expectedColumns;
  try {
    parsed = parseTypeDump(dumpText);
    expectedColumns = frozenDesktopSchemaColumns(await readFile(DESKTOP_SCHEMA));
  } catch (e) {
    console.error(`TYPE_PARITY_FAIL cannot establish the desktop column denominator: ${e.message}`);
    process.exit(1);
  }
  const coverageProblems = typeDumpCoverageProblems(parsed, expectedColumns);
  if (coverageProblems.length) {
    console.error(
      `TYPE_PARITY_FAIL dump coverage is not the exact ${expectedColumns.size}-column desktop schema`,
    );
    for (const problem of coverageProblems) console.error(`  ${problem}`);
    process.exit(1);
  }
  const desktop = parsed.columns;

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
  if (
    !Array.isArray(baseline.columns) ||
    baseline.columns.some((column) => typeof column !== 'string' || !column.trim()) ||
    new Set(baseline.columns).size !== baseline.columns.length
  ) {
    console.error('TYPE_PARITY_FAIL baseline columns must be unique nonblank strings');
    process.exit(1);
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
  if (process.argv.includes('--release') && mismatches.length) {
    console.error(
      `TYPE_PARITY_RED release requires zero numeric/text domain mismatch(es); ${mismatches.length} remain`,
    );
    for (const mismatch of mismatches.slice(0, 20)) {
      console.error(`    ${mismatch.column}: desktop ${mismatch.desktop} -> web ${mismatch.web}`);
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

if (process.argv[1] && path.resolve(process.argv[1]) === fileURLToPath(import.meta.url)) {
  main().catch((e) => {
    console.error('TYPE_PARITY_FAIL', e?.message ?? e);
    process.exit(1);
  });
}
