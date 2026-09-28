#!/usr/bin/env node
/**
 * Desktop-side extractor. RUN THIS ON THE WINDOWS BOX where DataCareNext is installed.
 *
 * WHAT IT DOES
 * ------------
 * After an operator enters a voucher by hand in the desktop application, this reads everything that voucher
 * wrote from SQL Server and writes a portable bundle. It does not compare anything and it never writes to the
 * database — it only reads.
 *
 * WHY THE WINDOWS STEP IS ONLY AN EXTRACTION
 * ------------------------------------------
 * The previous harness compared in flight, which meant every defect in the comparison logic had to be found
 * during a session on that machine. Extraction is now the only thing that needs to happen there, it is
 * read-only, and the resulting bundle is a retained artifact that can be re-compared later after a fix,
 * against exactly the same data.
 *
 * HOW THE TABLE SET IS CHOSEN
 * ---------------------------
 * Every table in the database that carries `CO_BOOK` and `VCH_NO` is probed for rows belonging to the voucher.
 * The set is therefore discovered from the DESKTOP's own schema, not from a list, and not from what the web
 * happens to have. A table the desktop writes and the web does not will appear in the bundle and be reported
 * as a missing write.
 *
 * USAGE
 *   set PARITY_MSSQL_HOST=localhost
 *   set PARITY_MSSQL_DATABASE=DataCare
 *   set PARITY_MSSQL_USER=sa
 *   set PARITY_MSSQL_PASSWORD=...
 *   set PARITY_COMPANY=01
 *   set PARITY_CASES=[{"caseId":"sale-cash-1","description":"...","book":"SL","vchNo":"00007"}]
 *   node apps/api/integration/parity-extract-mssql.mjs
 *
 * Windows authentication instead of a SQL login: set PARITY_MSSQL_TRUSTED=1 and omit user/password.
 */

import { mkdir, writeFile } from 'node:fs/promises';
import { dirname, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';

const HERE = dirname(fileURLToPath(import.meta.url));
const REPO = resolve(HERE, '../../..');
/**
 * Where the bundle is written.
 *
 * `PARITY_OUT_DIR` overrides the repository-relative default so this file can be run STANDALONE — copied on
 * its own to the Windows box next to an `npm i mssql`, with no checkout of the workspace. It imports only Node
 * builtins plus `mssql`, so nothing else is needed, and keeping that true matters: the fewer moving parts on
 * the machine with the desktop install, the fewer ways the session can fail.
 */
const OUT_DIR = String(process.env.PARITY_OUT_DIR ?? '').trim()
  ? resolve(process.cwd(), String(process.env.PARITY_OUT_DIR).trim())
  : resolve(REPO, '..', 'project-memory', 'parity', 'bundles');

/**
 * Tables that carry CO_BOOK and VCH_NO but whose (CO_BOOK, VCH_NO) does NOT identify a voucher in that book.
 *
 * Both extractors discover their table set from the schema on purpose, so a table the desktop writes and the
 * web does not will surface. `OP_LDR` breaks the assumption behind that discovery rather than being a genuine
 * missing write, and had to be excluded once the comparison scaled past a single voucher:
 *
 *   * 7011 rows across 35 books, all under ONE CO_YEAR;
 *   * in book 035 it holds 77 distinct VCH_NO where PR_DATA holds 29, and 50 of those 77 do not exist in
 *     PR_DATA at all;
 *   * its VCH_DATE values fall in the PRIOR year (2023) while the year being compared is 2024-2025.
 *
 * It is the year-end/opening ledger snapshot written by the import utility and read by one report — not a
 * posting target. Matching it on (book, vchNo) therefore pulled unrelated prior-year rows into every case and
 * produced 55 "the web never wrote this table" findings plus 64 missing rows of pure noise, which is worse
 * than useless: it made all 66 cases fail for a reason that is not a defect.
 *
 * Set PARITY_EXCLUDE_TABLES to override (comma separated). The SAME set must apply on both sides, or the
 * differ reports a one-sided table.
 */
const NON_VOUCHER_TABLES = new Set(
  (process.env.PARITY_EXCLUDE_TABLES ?? 'OP_LDR')
    .split(',')
    .map((s) => s.trim().toUpperCase())
    .filter(Boolean),
);

const IDENT = /^[A-Za-z_][A-Za-z0-9_]*$/;
const qms = (v) => {
  if (!IDENT.test(v)) throw new Error(`unsafe SQL identifier: ${v}`);
  return `[${v}]`;
};

function env(name, fallback) {
  const v = String(process.env[name] ?? '').trim();
  if (v) return v;
  if (fallback !== undefined) return fallback;
  throw new Error(`${name} is required`);
}

function parseCases() {
  const raw = env('PARITY_CASES');
  const cases = JSON.parse(raw);
  if (!Array.isArray(cases) || !cases.length)
    throw new Error('PARITY_CASES must be a non-empty array');
  return cases.map((c, i) => {
    for (const k of ['caseId', 'book', 'vchNo']) {
      if (!String(c?.[k] ?? '').trim()) throw new Error(`PARITY_CASES[${i}].${k} is required`);
    }
    return {
      caseId: String(c.caseId).trim(),
      description: String(c.description ?? '').trim(),
      book: String(c.book).trim(),
      vchNo: String(c.vchNo).trim(),
      coYear: c.coYear == null ? undefined : String(c.coYear).trim(),
    };
  });
}

async function main() {
  let sql;
  try {
    sql = (await import('mssql')).default;
  } catch {
    console.error(
      'PARITY_EXTRACT_FAIL the "mssql" package is not installed.\n' +
        '  Standalone (this file copied on its own):   npm i mssql\n' +
        '  Inside a checkout of the workspace:         pnpm add -w -D mssql\n' +
        '  It is a driver used only for this extraction and is not needed to run the application.',
    );
    process.exit(2);
  }

  const database = env('PARITY_MSSQL_DATABASE');
  const company = env('PARITY_COMPANY', '01');
  const location = String(process.env.PARITY_LOCATION ?? '').trim() || undefined;
  const cases = parseCases();

  const trusted = /^(1|true|yes)$/i.test(process.env.PARITY_MSSQL_TRUSTED ?? '');
  const config = {
    server: env('PARITY_MSSQL_HOST', 'localhost'),
    port: Number(process.env.PARITY_MSSQL_PORT || 1433),
    database,
    options: {
      // A local desktop SQL Server normally presents a self-signed certificate.
      encrypt: /^(1|true|yes)$/i.test(process.env.PARITY_MSSQL_ENCRYPT ?? 'false'),
      trustServerCertificate: true,
      // The driver must hand back UTC-normalised dates so canonicalisation is timezone-independent.
      useUTC: true,
    },
    requestTimeout: Number(process.env.PARITY_REQUEST_TIMEOUT_MS || 120000),
  };
  if (trusted) {
    config.authentication = { type: 'ntlm', options: { domain: process.env.USERDOMAIN ?? '' } };
  } else {
    config.user = env('PARITY_MSSQL_USER');
    config.password = env('PARITY_MSSQL_PASSWORD');
  }

  const pool = await sql.connect(config);
  try {
    // Provenance: the exact SQL Server and application build being compared against.
    const ver = await pool.request().query('SELECT @@VERSION AS v');
    const serverVersion = String(ver.recordset[0]?.v ?? '').split('\n')[0];

    // Discover every voucher-shaped table from the DESKTOP schema.
    const tablesRs = await pool.request().query(`
      SELECT TABLE_NAME AS name
        FROM INFORMATION_SCHEMA.COLUMNS
       WHERE TABLE_SCHEMA='dbo' AND COLUMN_NAME IN ('CO_BOOK','VCH_NO')
       GROUP BY TABLE_NAME
      HAVING COUNT(DISTINCT COLUMN_NAME)=2
       ORDER BY TABLE_NAME`);
    const candidateTables = tablesRs.recordset
      .map((r) => String(r.name))
      .filter((t) => !NON_VOUCHER_TABLES.has(t.toUpperCase()));
    if (!candidateTables.length)
      throw new Error('no voucher-shaped tables found; check the database name');

    // Column metadata once per table: name, type and SCALE. Scale is what lets the comparison run at the
    // precision the store actually keeps instead of a guessed number of decimals.
    const metaRs = await pool.request().query(`
      SELECT TABLE_NAME AS t, COLUMN_NAME AS c, DATA_TYPE AS ty, NUMERIC_SCALE AS sc
        FROM INFORMATION_SCHEMA.COLUMNS
       WHERE TABLE_SCHEMA='dbo'
       ORDER BY TABLE_NAME, ORDINAL_POSITION`);
    const metaByTable = new Map();
    for (const row of metaRs.recordset) {
      const t = String(row.t).toUpperCase();
      if (!metaByTable.has(t)) metaByTable.set(t, []);
      metaByTable.get(t).push({
        name: String(row.c),
        type: String(row.ty).toLowerCase(),
        scale: row.sc === null || row.sc === undefined ? null : Number(row.sc),
      });
    }

    const outCases = [];
    for (const c of cases) {
      const tables = {};
      for (const table of candidateTables) {
        const columns = metaByTable.get(table.toUpperCase()) ?? [];
        const hasCo = columns.some((x) => x.name.toUpperCase() === 'CO_CODE');
        const hasLc = columns.some((x) => x.name.toUpperCase() === 'LC_CODE');
        const hasYr = columns.some((x) => x.name.toUpperCase() === 'CO_YEAR');

        let where = 'CO_BOOK=@book AND VCH_NO=@voucher';
        if (hasCo) where += ' AND CO_CODE=@company';
        if (hasLc && location) where += ' AND LC_CODE=@location';
        if (hasYr && c.coYear) where += ' AND CO_YEAR=@coYear';

        const req = pool
          .request()
          .input('book', sql.NVarChar(50), c.book)
          .input('voucher', sql.NVarChar(100), c.vchNo)
          .input('company', sql.NVarChar(50), company);
        if (location) req.input('location', sql.NVarChar(50), location);
        if (c.coYear) req.input('coYear', sql.NVarChar(50), c.coYear);

        let rs;
        try {
          rs = await req.query(`SELECT * FROM dbo.${qms(table)} WHERE ${where}`);
        } catch (e) {
          console.error(`  ! ${table}: ${e instanceof Error ? e.message : String(e)}`);
          continue;
        }
        if (!rs.recordset.length) continue;

        // Row values are emitted in COLUMN ORDER so the bundle is compact and self-describing.
        const order = columns.map((x) => x.name);
        const rows = rs.recordset.map((r) =>
          order.map((name) => {
            const key = Object.keys(r).find((k) => k.toUpperCase() === name.toUpperCase());
            const v = key === undefined ? null : r[key];
            // Dates are serialised as ISO so the bundle is plain JSON; the differ parses them back by shape.
            return v instanceof Date ? v.toISOString() : typeof v === 'bigint' ? v.toString() : v;
          }),
        );
        tables[table.toUpperCase()] = { columns, rows };
      }
      const tableCount = Object.keys(tables).length;
      if (!tableCount) {
        console.error(
          `PARITY_EXTRACT_FAIL case ${c.caseId}: voucher ${c.book}/${c.vchNo} wrote no rows in any table.\n` +
            '  The voucher number or book is wrong, or the voucher was not saved.',
        );
        process.exit(1);
      }
      console.log(`  ${c.caseId}: ${c.book}/${c.vchNo} -> ${tableCount} tables`);
      outCases.push({
        caseId: c.caseId,
        description: c.description,
        voucher: { book: c.book, vchNo: c.vchNo, coYear: c.coYear },
        tables,
      });
    }

    const bundle = {
      kind: 'datacare.parity-bundle/1.0',
      side: 'desktop',
      capturedAt: new Date().toISOString(),
      source: {
        engine: 'sqlserver',
        database,
        host: config.server,
        appVersion: serverVersion,
      },
      scope: { coCode: company, lcCode: location, coYear: cases[0]?.coYear },
      cases: outCases,
    };

    await mkdir(OUT_DIR, { recursive: true });
    const path = resolve(OUT_DIR, `desktop-${bundle.capturedAt.replace(/[:.]/g, '-')}.json`);
    await writeFile(path, `${JSON.stringify(bundle, null, 1)}\n`, 'utf8');
    // A stable name for the compare step, alongside the timestamped archive copy.
    await writeFile(
      resolve(OUT_DIR, 'desktop-latest.json'),
      `${JSON.stringify(bundle, null, 1)}\n`,
      'utf8',
    );
    console.log(`PARITY_EXTRACT_OK ${outCases.length} case(s) -> ${path}`);
  } finally {
    await pool.close();
  }
}

main().catch((e) => {
  console.error(`PARITY_EXTRACT_FAIL ${e instanceof Error ? e.message : String(e)}`);
  process.exit(1);
});
