#!/usr/bin/env node
/**
 * Web-side extractor. Produces the same bundle shape as the desktop extractor, from PostgreSQL.
 *
 * Deliberately mirrors `parity-extract-mssql.mjs` rather than sharing code with it: the two engines report
 * metadata differently, and a shared abstraction would have to guess which behaviour is canonical. Keeping
 * them separate means each is obviously correct for its own engine, and the BUNDLE is the contract between
 * them.
 *
 * Like the desktop side, the table set is discovered from the schema — every table carrying `CO_BOOK` and
 * `VCH_NO` is probed. Neither side's table list is filtered by the other's, so a missing write surfaces.
 *
 * USAGE
 *   DATABASE_URL=postgresql://... \
 *   PARITY_TENANT=default PARITY_COMPANY=01 \
 *   PARITY_CASES='[{"caseId":"sale-cash-1","book":"SL","vchNo":"00001"}]' \
 *   node apps/api/integration/parity-extract-pg.mjs
 */

import { mkdir, writeFile } from 'node:fs/promises';
import { createRequire } from 'node:module';
import { dirname, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';

const HERE = dirname(fileURLToPath(import.meta.url));
const REPO = resolve(HERE, '../../..');
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
const qpg = (v) => {
  if (!IDENT.test(v)) throw new Error(`unsafe SQL identifier: ${v}`);
  return `"${v}"`;
};

function env(name, fallback) {
  const v = String(process.env[name] ?? '').trim();
  if (v) return v;
  if (fallback !== undefined) return fallback;
  throw new Error(`${name} is required`);
}

function parseCases() {
  const cases = JSON.parse(env('PARITY_CASES'));
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
  const url = env('DATABASE_URL');
  const tenant = env('PARITY_TENANT', 'default');
  const company = env('PARITY_COMPANY', '01');
  const location = String(process.env.PARITY_LOCATION ?? '').trim() || undefined;
  const cases = parseCases();

  // pnpm hoists nothing to the workspace root, so the client is resolved from the package that depends on it.
  const req = createRequire(resolve(REPO, 'packages', 'db', 'package.json'));
  const { PrismaClient } = req('@prisma/client');
  const prisma = new PrismaClient({ datasources: { db: { url } } });

  // Every read below must carry the tenant context. DATABASE_URL is the RLS-BOUND application role, and
  // without `app.tenant_id` set, row-level security filters every table to nothing - so this script reported
  // "voucher wrote no rows" for a voucher that was sitting right there. It reads as a missing voucher, not as
  // a permissions failure, which is the whole danger of it.
  //
  // Transaction-local set_config is what packages/db/withTenant does; doing it per statement here would not
  // survive, so the reads are wrapped in one interactive transaction instead.
  const inTenant = (fn) =>
    prisma.$transaction(async (tx) => {
      await tx.$executeRawUnsafe("SELECT set_config('app.tenant_id', $1, true)", tenant);
      return fn(tx);
    });

  try {
    const tableRows = await prisma.$queryRawUnsafe(`
      SELECT table_name AS name FROM information_schema.columns
       WHERE table_schema='public' AND upper(column_name) IN ('CO_BOOK','VCH_NO')
       GROUP BY table_name HAVING count(DISTINCT upper(column_name))=2
       ORDER BY table_name`);
    const candidateTables = tableRows
      .map((r) => String(r.name))
      .filter((t) => !NON_VOUCHER_TABLES.has(t.toUpperCase()));
    if (!candidateTables.length) throw new Error('no voucher-shaped tables found');

    const metaRows = await prisma.$queryRawUnsafe(`
      SELECT table_name AS t, column_name AS c, data_type AS ty, numeric_scale AS sc
        FROM information_schema.columns
       WHERE table_schema='public'
       ORDER BY table_name, ordinal_position`);
    const metaByTable = new Map();
    for (const row of metaRows) {
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
        const has = (n) => columns.some((x) => x.name.toUpperCase() === n);
        const params = [tenant, c.book, c.vchNo];
        let where = `tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`;
        if (has('CO_CODE')) {
          params.push(company);
          where += ` AND "CO_CODE"=$${params.length}`;
        }
        if (has('LC_CODE') && location) {
          params.push(location);
          where += ` AND "LC_CODE"=$${params.length}`;
        }
        if (has('CO_YEAR') && c.coYear) {
          params.push(c.coYear);
          where += ` AND "CO_YEAR"=$${params.length}`;
        }
        let rows;
        try {
          // RLS is not the subject of this comparison, and a policy miss would look like a missing write -
          // which is a misleading finding, so guard against it from both directions. Setting the tenant
          // context is required if DATABASE_URL names the RLS-bound application role and harmless if it names
          // the owner, so the script works either way rather than reporting an empty voucher.
          rows = await inTenant((tx) =>
            tx.$queryRawUnsafe(`SELECT * FROM ${qpg(table)} WHERE ${where}`, ...params),
          );
        } catch (e) {
          console.error(`  ! ${table}: ${e instanceof Error ? e.message : String(e)}`);
          continue;
        }
        if (!rows.length) continue;
        const order = columns.map((x) => x.name);
        tables[table.toUpperCase()] = {
          columns,
          rows: rows.map((r) =>
            order.map((name) => {
              const key = Object.keys(r).find((k) => k.toUpperCase() === name.toUpperCase());
              const v = key === undefined ? null : r[key];
              if (v instanceof Date) return v.toISOString();
              if (typeof v === 'bigint') return v.toString();
              // Prisma returns numeric as Decimal-like objects; their text form preserves scale.
              if (v && typeof v === 'object' && typeof v.toFixed === 'function') return String(v);
              return v;
            }),
          ),
        };
      }
      const tableCount = Object.keys(tables).length;
      if (!tableCount) {
        console.error(
          `PARITY_EXTRACT_FAIL case ${c.caseId}: voucher ${c.book}/${c.vchNo} wrote no rows.\n` +
            '  Check PARITY_TENANT, the book and the voucher number.',
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
      side: 'web',
      capturedAt: new Date().toISOString(),
      source: {
        engine: 'postgres',
        database: (url.match(/\/([^/?]+)(\?|$)/) ?? [, 'unknown'])[1],
      },
      scope: { coCode: company, lcCode: location, coYear: cases[0]?.coYear },
      cases: outCases,
    };

    await mkdir(OUT_DIR, { recursive: true });
    const path = resolve(OUT_DIR, `web-${bundle.capturedAt.replace(/[:.]/g, '-')}.json`);
    await writeFile(path, `${JSON.stringify(bundle, null, 1)}\n`, 'utf8');
    await writeFile(
      resolve(OUT_DIR, 'web-latest.json'),
      `${JSON.stringify(bundle, null, 1)}\n`,
      'utf8',
    );
    console.log(`PARITY_EXTRACT_OK ${outCases.length} case(s) -> ${path}`);
  } finally {
    await prisma.$disconnect();
  }
}

main().catch((e) => {
  console.error(`PARITY_EXTRACT_FAIL ${e instanceof Error ? e.message : String(e)}`);
  process.exit(1);
});
