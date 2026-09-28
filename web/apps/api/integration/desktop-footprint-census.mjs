#!/usr/bin/env node
/**
 * DESKTOP WRITE-SET FOOTPRINT CENSUS — every voucher family, measured from real data.
 *
 * WHY THIS EXISTS
 * ===============
 * The parity harness compares ONE voucher end-to-end (extract → replay → diff). That is the strongest kind
 * of evidence, but each replay needs a hand-built seed and payload, so after weeks exactly one voucher of
 * 1567 had ever been compared. Scaling that way is linear in vouchers.
 *
 * This tool answers a different, cheaper question across the WHOLE database at once:
 *
 *     for every book the shop actually used, which tables does a voucher touch, how many rows does it
 *     write to each, and which columns are actually populated?
 *
 * That is the specification the web must satisfy. It does not prove the web matches — only a replay diff
 * does that — but it bounds the problem: any table/column the desktop writes and the web has no write path
 * for is a gap that no amount of per-voucher replaying will reveal if the replay never covers that family.
 *
 * OUTPUT
 * ------
 * A JSON document keyed by book, each carrying:
 *   family      MAIN_BOOK (the voucher family)
 *   headerTable BOOK_TBL_NAME as configured (may be null — several live books leave it unset)
 *   vouchers    distinct VCH_NO count
 *   tables      per table: vouchersTouching, totalRows, rowsPerVoucher {min,max,avg}
 *   columns     per table: populated column names (non-null, non-zero, non-blank on at least one row)
 *
 * Reads only counts, structure and column names. NO customer values are emitted: Live24 is real customer
 * data, so every projection here is an aggregate or a column name.
 *
 * USAGE
 *   node apps/api/integration/desktop-footprint-census.mjs                  # all books
 *   CENSUS_BOOKS=035,032 node apps/api/integration/desktop-footprint-census.mjs
 *   CENSUS_OUT=/tmp/census.json node ...
 */
import { execFile } from 'node:child_process';
import { writeFile } from 'node:fs/promises';
import { promisify } from 'node:util';

const run = promisify(execFile);

const CONTAINER = process.env.CENSUS_CONTAINER ?? 'dc-mssql';
const DB = process.env.CENSUS_DB ?? 'Live24';
const SA_PASSWORD = process.env.CENSUS_SA_PASSWORD ?? 'ParityProbe#2026x';
const OUT = process.env.CENSUS_OUT ?? 'project-memory/parity/DESKTOP-FOOTPRINT-CENSUS.json';
const ONLY_BOOKS = (process.env.CENSUS_BOOKS ?? '')
  .split(',')
  .map((s) => s.trim())
  .filter(Boolean);

/** Row separator that cannot appear in an identifier or an aggregate number. */
const SEP = '\u0001';

/**
 * Run a query through sqlcmd inside the container.
 *
 * Empty output is treated as a FAILURE, not as "no rows": the container is amd64 under emulation and does
 * stop, and a stopped container returns nothing, which previously read as a genuine zero-row finding twice
 * in one day. Callers that legitimately expect no rows pass allowEmpty.
 */
async function sql(query, { allowEmpty = false } = {}) {
  const args = [
    'exec',
    CONTAINER,
    '/opt/mssql-tools18/bin/sqlcmd',
    '-S',
    'localhost',
    '-U',
    'sa',
    '-P',
    SA_PASSWORD,
    '-C',
    '-W',
    '-h',
    '-1',
    '-s',
    SEP,
    '-d',
    DB,
    '-Q',
    `SET NOCOUNT ON; ${query}`,
  ];
  let stdout = '';
  try {
    ({ stdout } = await run('docker', args, { maxBuffer: 64 * 1024 * 1024 }));
  } catch (e) {
    throw new Error(`sqlcmd failed: ${String(e?.stderr || e?.message || e).slice(0, 300)}`);
  }
  if (/Msg \d+|Login failed|not running|Cannot open database/i.test(stdout)) {
    throw new Error(`sqlcmd reported an error: ${stdout.split('\n').slice(0, 3).join(' ')}`);
  }
  const rows = stdout
    .split('\n')
    .map((l) => l.replace(/\r$/, ''))
    .filter((l) => l.trim().length > 0)
    .map((l) => l.split(SEP).map((c) => c.trim()));
  if (!allowEmpty && rows.length === 0) {
    throw new Error(
      'sqlcmd returned nothing — treat as failure, check: docker ps | grep ' + CONTAINER,
    );
  }
  return rows;
}

/** Tables that carry voucher-scoped rows: they have CO_BOOK and VCH_NO. */
async function voucherTables() {
  const rows = await sql(`
    SELECT t.name
      FROM sys.tables t
     WHERE EXISTS (SELECT 1 FROM sys.columns c WHERE c.object_id=t.object_id AND c.name='CO_BOOK')
       AND EXISTS (SELECT 1 FROM sys.columns c WHERE c.object_id=t.object_id AND c.name='VCH_NO')
     ORDER BY t.name`);
  return rows.map((r) => r[0]);
}

/** Books that actually carry ledger activity, with their configured family and header table. */
async function books() {
  const rows = await sql(`
    SELECT b.CO_BOOK ${SEP === '' ? '' : ''}
         , ISNULL(b.MAIN_BOOK,'')
         , ISNULL(b.BOOK_TBL_NAME,'')
         , ISNULL(b.BOOK_SNAME,'')
         , ISNULL(b.CUR_USE,'')
         , CAST(COUNT(DISTINCT a.VCH_NO) AS varchar)
      FROM BOOK_DATA b
      JOIN AC_DATA a ON a.CO_BOOK=b.CO_BOOK AND a.CO_CODE=b.CO_CODE
     GROUP BY b.CO_BOOK,b.MAIN_BOOK,b.BOOK_TBL_NAME,b.BOOK_SNAME,b.CUR_USE
    HAVING COUNT(DISTINCT a.VCH_NO)>0
     ORDER BY b.CO_BOOK`);
  return rows
    .map(([book, family, headerTable, sname, curUse, vouchers]) => ({
      book,
      family: family || null,
      headerTable: headerTable || null,
      shortName: sname || null,
      currentlyUsed: curUse === 'Y',
      vouchers: Number(vouchers),
    }))
    .filter((b) => !ONLY_BOOKS.length || ONLY_BOOKS.includes(b.book));
}

/**
 * Per-table row statistics for one book, in a single query per book.
 *
 * One UNION ALL over every voucher table keeps this to ~40 round trips instead of 40 × 90.
 */
async function tableStatsForBook(book, tables) {
  const parts = tables.map(
    (t) => `
    SELECT '${t}' AS tbl,
           CAST(COUNT(DISTINCT VCH_NO) AS varchar) AS vch,
           CAST(COUNT(*) AS varchar) AS rows_,
           CAST(MIN(c) AS varchar) AS mn, CAST(MAX(c) AS varchar) AS mx,
           CAST(CAST(AVG(CAST(c AS float)) AS decimal(10,2)) AS varchar) AS av
      FROM (SELECT VCH_NO, COUNT(*) OVER (PARTITION BY VCH_NO) c FROM [${t}] WHERE CO_BOOK='${book}') x
     HAVING COUNT(*)>0`,
  );
  const rows = await sql(parts.join(' UNION ALL '), { allowEmpty: true });
  const out = {};
  for (const [tbl, vch, total, mn, mx, av] of rows) {
    if (!tbl) continue;
    out[tbl] = {
      vouchersTouching: Number(vch),
      totalRows: Number(total),
      rowsPerVoucher: { min: Number(mn), max: Number(mx), avg: Number(av) },
    };
  }
  return out;
}

/**
 * Which columns of `table` are actually populated for `book`.
 *
 * "Populated" = at least one row where the value is not NULL, not blank and not a zero numeric. That
 * distinction matters: a column present in the schema but never written is not part of the desktop's real
 * write set, and holding the web to it would manufacture false gaps. Binary/rowversion types are skipped.
 */
async function populatedColumns(book, table) {
  const cols = await sql(
    `SELECT c.name
       FROM sys.columns c
      WHERE c.object_id=OBJECT_ID('${table}')
        AND c.system_type_id NOT IN (34,35,99,165,173,189)
      ORDER BY c.name`,
    { allowEmpty: true },
  );
  const names = cols.map((r) => r[0]).filter(Boolean);
  if (!names.length) return [];
  const exprs = names.map(
    (n) =>
      // A derived table with TOP 1 avoids `GROUP BY <literal>`, which SQL Server rejects with
      // "Each GROUP BY expression must contain at least one column that is not an outer reference".
      `SELECT '${n}' AS col FROM (SELECT TOP 1 1 AS x FROM [${table}] WHERE CO_BOOK='${book}' AND ` +
      `LTRIM(RTRIM(ISNULL(CAST([${n}] AS varchar(64)),''))) NOT IN ('','0','0.0','0.00','0.000','0.0000')) q_${n.replace(/[^A-Za-z0-9_]/g, '')}`,
  );
  // Chunked: a single statement over ~200 columns exceeds practical batch limits on some tables.
  const found = [];
  const CHUNK = 40;
  for (let i = 0; i < exprs.length; i += CHUNK) {
    const rows = await sql(exprs.slice(i, i + CHUNK).join(' UNION ALL '), { allowEmpty: true });
    for (const [c] of rows) if (c) found.push(c);
  }
  return found.sort();
}

async function main() {
  const started = Date.now();
  const banner = (await sql(`SELECT LEFT(CAST(@@VERSION AS varchar(200)),90)`))[0][0];
  const tables = await voucherTables();
  const bookList = await books();
  console.log(
    `census: ${bookList.length} book(s), ${tables.length} voucher-scoped table(s), database ${DB}`,
  );

  const out = {
    kind: 'datacare.desktop-footprint-census/1.0',
    capturedAt: new Date().toISOString(),
    source: { engine: 'sqlserver', database: DB, appVersion: banner },
    note:
      'Row/column aggregates only — no customer values. "populatedColumns" means at least one row carried a ' +
      'non-null, non-blank, non-zero value for that column in that book.',
    voucherScopedTables: tables.length,
    books: {},
  };

  for (const b of bookList) {
    const stats = await tableStatsForBook(b.book, tables);
    const touched = Object.keys(stats).sort();
    const columns = {};
    for (const t of touched) columns[t] = await populatedColumns(b.book, t);
    out.books[b.book] = { ...b, tables: stats, populatedColumns: columns };
    console.log(
      `  ${b.book} ${String(b.family ?? '(blank)').padEnd(16)} vouchers=${String(b.vouchers).padStart(4)} tables=${touched.length}`,
    );
  }

  await writeFile(OUT, JSON.stringify(out, null, 2) + '\n');
  const secs = ((Date.now() - started) / 1000).toFixed(1);
  console.log(`CENSUS_OK ${OUT} (${secs}s)`);
}

main().catch((e) => {
  console.error('CENSUS_FAIL', e?.message ?? e);
  process.exit(1);
});
