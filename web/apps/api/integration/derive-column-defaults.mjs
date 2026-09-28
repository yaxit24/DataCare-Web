#!/usr/bin/env node
/**
 * DERIVE THE COLUMN-DEFAULT SPECIFICATION FROM THE DESKTOP DATA.
 *
 * WHY A MEASURED SPEC RATHER THAN A RULE
 * ======================================
 * The desktop's data layer writes a COMPLETE row: numeric columns it does not use get 0, character columns
 * get ''. The web built each INSERT from only the columns a caller supplied, so everything else became NULL.
 * In the 66-voucher comparison that single difference accounted for 5239 of 8080 field differences.
 *
 * Defaulting by TYPE alone over-reaches, and the comparison proved it: filling every numeric with 0 and every
 * character with '' removed 3057 differences but INTRODUCED 828 new ones across 17 columns that the desktop
 * genuinely leaves NULL — PR_DETL.CONSI_NO/CONSI_YRCD/CONSI_DBCD, PR_DETL.HM_ID2/3/4, ITM_COLOR, ITM_LOT,
 * PR_DATA.HM_TAX_CODE, RATE_CUT_DATA.VP_AMT_TYPE/AC_ANGDIYA/TDS_CODE and others.
 *
 * A hand-maintained exclusion list is incomplete by construction: it can only ever contain the columns some
 * comparison happened to surface. So this tool measures the answer instead — for every voucher-scoped column,
 * does the desktop EVER store NULL?
 *
 *   never NULL, and numeric or character  ->  the web should write the desktop's default (0 or '')
 *   ever NULL                             ->  leave it NULL; the desktop uses NULL meaningfully
 *   no rows to judge from                 ->  leave it NULL (absence of evidence is not evidence)
 *
 * Dates are never defaulted regardless: the desktop leaves an unset date NULL, which is already documented
 * for AC_DATA.BILL_DATE, and a zero date is meaningless.
 *
 * OUTPUT  packages/db/desktop-column-defaults.json  — consumed by insertRowTx in posting.ts.
 *
 * USAGE
 *   PARITY_MSSQL_DATABASE=Live24 node apps/api/integration/derive-column-defaults.mjs
 */
import { writeFile } from 'node:fs/promises';
import { dirname, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';

const HERE = dirname(fileURLToPath(import.meta.url));
const REPO = resolve(HERE, '../../..');
// Emitted as TypeScript, not JSON: `tsc` type-checks a JSON import but does not copy the file into dist, so
// a .json here would compile and then fail to resolve at runtime. A .ts module compiles like any other source.
const OUT =
  process.env.DEFAULTS_OUT ??
  resolve(REPO, 'apps/api/src/modules/posting/desktopColumnDefaults.ts');

const NUMERIC = new Set([
  'decimal',
  'numeric',
  'int',
  'bigint',
  'smallint',
  'tinyint',
  'float',
  'real',
  'money',
  'smallmoney',
]);
const CHARACTER = new Set(['varchar', 'nvarchar', 'char', 'nchar', 'text', 'ntext']);

/**
 * Identity columns that must always come from the caller and are therefore never defaulted.
 *
 * Silently supplying '' for a voucher key would turn "the caller forgot the book" into a row with a blank
 * key, which is far worse than a failed insert: it writes an orphan the reports cannot find.
 */
const NEVER_DEFAULT = new Set([
  'CO_CODE',
  'LC_CODE',
  'CO_YEAR',
  'CO_BOOK',
  'VCH_NO',
  'SR_NO',
  'VCH_SRNO',
  'LEDR_KEY',
  'AC_CODE',
]);

const env = (n, d) => {
  const v = String(process.env[n] ?? '').trim();
  if (v) return v;
  if (d !== undefined) return d;
  throw new Error(`${n} is required`);
};

async function main() {
  const mssql = (await import('mssql')).default;
  const pool = await mssql.connect({
    server: env('PARITY_MSSQL_SERVER', '127.0.0.1'),
    port: Number(env('PARITY_MSSQL_PORT', '11433')),
    database: env('PARITY_MSSQL_DATABASE', 'Live24'),
    user: env('PARITY_MSSQL_USER', 'sa'),
    password: env('PARITY_MSSQL_PASSWORD', 'ParityProbe#2026x'),
    options: { encrypt: true, trustServerCertificate: true, enableArithAbort: true },
    requestTimeout: 300000,
  });

  // Voucher-scoped tables only: those are the ones a posting path writes.
  const tables = (
    await pool.request().query(`
      SELECT TABLE_NAME AS name
        FROM INFORMATION_SCHEMA.COLUMNS
       WHERE TABLE_SCHEMA='dbo' AND COLUMN_NAME IN ('CO_BOOK','VCH_NO')
       GROUP BY TABLE_NAME HAVING COUNT(DISTINCT COLUMN_NAME)=2
       ORDER BY TABLE_NAME`)
  ).recordset.map((r) => String(r.name));

  const cols = new Map();
  for (const r of (
    await pool.request().query(`
      SELECT TABLE_NAME t, COLUMN_NAME c, DATA_TYPE ty
        FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='dbo'`)
  ).recordset) {
    if (!cols.has(r.t)) cols.set(r.t, []);
    cols.get(r.t).push({ name: String(r.c), type: String(r.ty).toLowerCase() });
  }

  const spec = {};
  let defaulted = 0;
  let leftNull = 0;
  let noEvidence = 0;

  for (const table of tables) {
    const candidates = (cols.get(table) ?? []).filter(
      (c) =>
        (NUMERIC.has(c.type) || CHARACTER.has(c.type)) && !NEVER_DEFAULT.has(c.name.toUpperCase()),
    );
    if (!candidates.length) continue;

    const total = (await pool.request().query(`SELECT COUNT(*) n FROM [${table}]`)).recordset[0].n;
    if (!total) {
      noEvidence += candidates.length;
      continue;
    }

    // One pass per table: how many NULLs each candidate column has.
    const CHUNK = 60;
    const nullCounts = {};
    for (let i = 0; i < candidates.length; i += CHUNK) {
      const part = candidates.slice(i, i + CHUNK);
      const sel = part
        .map((c) => `SUM(CASE WHEN [${c.name}] IS NULL THEN 1 ELSE 0 END) AS [${c.name}]`)
        .join(',');
      const row = (await pool.request().query(`SELECT ${sel} FROM [${table}]`)).recordset[0];
      for (const c of part) nullCounts[c.name] = Number(row[c.name] ?? 0);
    }

    const forTable = {};
    for (const c of candidates) {
      if (nullCounts[c.name] === 0) {
        forTable[c.name] = NUMERIC.has(c.type) ? 0 : '';
        defaulted++;
      } else {
        leftNull++;
      }
    }
    if (Object.keys(forTable).length) spec[table] = forTable;
  }

  const doc = {
    kind: 'datacare.desktop-column-defaults/1.0',
    derivedAt: new Date().toISOString(),
    source: { engine: 'sqlserver', database: env('PARITY_MSSQL_DATABASE', 'Live24') },
    note:
      'Columns the desktop NEVER leaves NULL, with the default it writes. Derived by counting NULLs per ' +
      'column over every row of every voucher-scoped table. Columns that are ever NULL, and columns in ' +
      'empty tables, are deliberately absent: insertRowTx leaves anything absent here as NULL.',
    counts: { tables: Object.keys(spec).length, defaulted, leftNull, noEvidence },
    defaults: spec,
  };
  const banner = `/**
 * GENERATED — do not edit by hand.
 *
 * Columns the desktop NEVER leaves NULL, with the default value it writes, derived by counting NULLs per
 * column over every row of every voucher-scoped table in the real database.
 *
 * Regenerate with:
 *   PARITY_MSSQL_DATABASE=Live24 node apps/api/integration/derive-column-defaults.mjs
 *
 * Derived ${doc.derivedAt} from ${doc.source.database} (${doc.source.engine}).
 * ${doc.counts.tables} table(s); ${doc.counts.defaulted} column(s) defaulted, ${doc.counts.leftNull} left NULL
 * because the desktop uses NULL there, ${doc.counts.noEvidence} with no rows to judge from.
 *
 * Consumed by insertRowTx in posting.ts, which documents why this is measured rather than a type rule.
 */
export const DESKTOP_COLUMN_DEFAULTS: Record<string, Record<string, number | string>> = `;
  await writeFile(OUT, banner + JSON.stringify(doc.defaults, null, 2) + ';\n');
  console.log(
    `DEFAULTS_OK ${OUT}\n  ${Object.keys(spec).length} table(s); ${defaulted} column(s) to default, ` +
      `${leftNull} left NULL (desktop uses NULL), ${noEvidence} with no rows to judge from`,
  );
  await pool.close();
}

main().catch((e) => {
  console.error('DEFAULTS_FAIL', e?.message ?? e);
  process.exit(1);
});
