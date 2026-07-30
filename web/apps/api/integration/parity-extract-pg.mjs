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

  try {
    const tableRows = await prisma.$queryRawUnsafe(`
      SELECT table_name AS name FROM information_schema.columns
       WHERE table_schema='public' AND upper(column_name) IN ('CO_BOOK','VCH_NO')
       GROUP BY table_name HAVING count(DISTINCT upper(column_name))=2
       ORDER BY table_name`);
    const candidateTables = tableRows.map((r) => String(r.name));
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
          // Read as the owner: RLS is not the subject of this comparison and a policy miss would look like a
          // missing write, which would be a misleading finding.
          rows = await prisma.$queryRawUnsafe(
            `SELECT * FROM ${qpg(table)} WHERE ${where}`,
            ...params,
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
