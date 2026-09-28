#!/usr/bin/env node
/**
 * IMPORT REAL DESKTOP MASTERS INTO POSTGRES FOR A PARITY TENANT.
 *
 * WHY THIS EXISTS — IT IS THE THING THAT BLOCKED SCALING
 * =====================================================
 * The parity harness has three generic pieces (extract-mssql, extract-pg, bundleDiff) and one piece that is
 * hand-written per voucher: the REPLAY. Reading `parity-replay-purchase.mjs`, almost all of it is a `seed()`
 * that hand-types the masters that one voucher needs — CO_SET rounding flags, CO_MAST, LOCT_MAST, YEAR_MAST,
 * four AC_MAST accounts, GROUP_MAST, ITEM_MAST, TAX_MAST, BOOK_DATA, three BOOK_DETL slots — each value
 * copied by hand out of Live24 and each a chance to introduce a fixture artifact.
 *
 * That is why exactly ONE voucher of 1567 had ever been compared: the cost per case was a bespoke fixture,
 * and a wrong fixture produces a difference that looks like a web defect. The purchase replay records one
 * such incident in its own comments — a hand-typed BOOK_SNAME of 'PURC' produced a VCH_TYPE difference that
 * was an artifact of the fixture, not a defect in `bookPolicy.ts`.
 *
 * This script removes that class of error and that cost: it copies the REAL master rows out of the desktop
 * database into Postgres under a parity tenant. Nothing is typed by hand, so nothing can be mistyped, and any
 * voucher in the database becomes replayable without new fixture work.
 *
 * WHAT IT COPIES
 * --------------
 * Configuration and masters only — never transaction tables. The voucher under test must be produced by the
 * WEB from its inputs; copying desktop transaction rows would compare the desktop to itself.
 *
 * COLUMN HANDLING
 * ---------------
 * The web schema is a verified superset of the desktop's (145/145 tables, 5231/5231 columns), so the copy
 * uses the INTERSECTION of the two column sets and lets web-only columns (tenant_id, row_id, ...) default.
 * A desktop column with no web counterpart would be a schema gap and is reported loudly rather than skipped.
 *
 * SAFETY
 * ------
 * Live24 is real customer data. This copies it into a LOCAL parity tenant for comparison and prints only
 * counts — no names reach stdout. Do not point PARITY_PG_URL at anything shared.
 *
 * USAGE
 *   PARITY_MSSQL_DATABASE=Live24 \
 *   PARITY_PG_URL='postgresql://postgres@127.0.0.1:55433/verify_all?schema=public' \
 *   PARITY_TENANT=parity-generic \
 *   node apps/api/integration/parity-import-masters.mjs
 */
import { PrismaClient } from '@prisma/client';

/**
 * Master / configuration tables to copy, in dependency order.
 *
 * Chosen by taking the union of the seeds in the four existing hand-written replays and adding the
 * configuration tables the posting engine reads (rounding flags, numbering, rates, touch).
 */
const MASTERS = [
  'CO_MAST',
  'CO_SET',
  'CO_SET_NEW',
  'LOCT_MAST',
  'YEAR_MAST',
  'AC_GROUP',
  'GROUP_MAST',
  'AC_MAST',
  'ITEM_MAST',
  'TAX_MAST',
  'BOOK_DATA',
  'BOOK_DETL',
  'RATE_MAST',
  'TOUCH_MAST',
  'ITM_WT_MAST',
  'LBR_MAST',
  'AD_MAST',
  'MEMB_MAST',
  'EMP_MAST',
  'DESIGN_MAST',
  'PRODUCT_MAST',
  'TABLE_MAST',
  'DM_MAST',
  'STYLE_MAST',
  'MFG_MAST',
];

const IDENT = /^[A-Za-z_][A-Za-z0-9_]*$/;
const q = (v) => {
  if (!IDENT.test(v)) throw new Error(`unsafe identifier: ${v}`);
  return `"${v}"`;
};

function env(name, fallback) {
  const v = String(process.env[name] ?? '').trim();
  if (v) return v;
  if (fallback !== undefined) return fallback;
  throw new Error(`${name} is required`);
}

async function main() {
  let mssql;
  try {
    mssql = (await import('mssql')).default;
  } catch {
    console.error('IMPORT_FAIL the "mssql" package is not installed. pnpm add -w mssql');
    process.exit(2);
  }

  const database = env('PARITY_MSSQL_DATABASE', 'Live24');
  const tenant = env('PARITY_TENANT', 'parity-generic');
  const pgUrl = env('PARITY_PG_URL');
  const company = String(process.env.PARITY_COMPANY ?? '').trim() || undefined;

  const pool = await mssql.connect({
    server: env('PARITY_MSSQL_SERVER', '127.0.0.1'),
    port: Number(env('PARITY_MSSQL_PORT', '11433')),
    database,
    user: env('PARITY_MSSQL_USER', 'sa'),
    password: env('PARITY_MSSQL_PASSWORD', 'ParityProbe#2026x'),
    options: { encrypt: true, trustServerCertificate: true, enableArithAbort: true },
    requestTimeout: 120000,
  });

  const prisma = new PrismaClient({ datasources: { db: { url: pgUrl } } });

  // Which of the requested tables exist on each side, and with which columns.
  const dsk = new Map();
  for (const r of (
    await pool.request().query(`
      SELECT t.name AS tbl, c.name AS col
        FROM sys.tables t JOIN sys.columns c ON c.object_id=t.object_id
       WHERE c.system_type_id NOT IN (34,35,99,165,173,189)`)
  ).recordset) {
    if (!dsk.has(r.tbl)) dsk.set(r.tbl, new Set());
    dsk.get(r.tbl).add(r.col);
  }

  const web = new Map();
  const webType = new Map();
  for (const r of await prisma.$queryRawUnsafe(
    `SELECT table_name AS tbl, column_name AS col, data_type AS typ
       FROM information_schema.columns WHERE table_schema='public'`,
  )) {
    if (!web.has(r.tbl)) web.set(r.tbl, new Set());
    web.get(r.tbl).add(r.col);
    webType.set(`${r.tbl}.${r.col}`, r.typ);
  }

  /**
   * Postgres will not implicitly coerce a text parameter into a date/numeric column, and Prisma binds most
   * JS values as text over the wire. Casting each placeholder to the DESTINATION column's type lets one
   * generic copy work across 25 masters without per-column special cases.
   */
  const castFor = (table, col) => {
    const t = String(webType.get(`${table}.${col}`) ?? '').toLowerCase();
    if (t === 'date') return '::date';
    if (t.startsWith('timestamp')) return '::timestamp';
    if (t === 'time without time zone' || t === 'time with time zone') return '::time';
    if (t === 'boolean') return '::boolean';
    if (['integer', 'smallint', 'bigint'].includes(t)) return '::bigint';
    if (['numeric', 'decimal', 'real', 'double precision'].includes(t)) return '::numeric';
    return '';
  };

  // Wipe the tenant so a re-run is deterministic rather than additive.
  const tenantTables = await prisma.$queryRawUnsafe(
    `SELECT table_name FROM information_schema.columns
      WHERE table_schema='public' AND column_name='tenant_id' ORDER BY table_name`,
  );
  for (const { table_name } of tenantTables) {
    await prisma.$executeRawUnsafe(`DELETE FROM ${q(table_name)} WHERE tenant_id=$1`, tenant);
  }
  console.log(`wiped tenant ${tenant} across ${tenantTables.length} table(s)`);

  const summary = [];
  const problems = [];

  for (const table of MASTERS) {
    if (!dsk.has(table)) {
      summary.push({ table, status: 'absent-on-desktop', rows: 0 });
      continue;
    }
    if (!web.has(table)) {
      problems.push(`${table}: exists on the desktop but NOT in the web schema`);
      summary.push({ table, status: 'MISSING-IN-WEB', rows: 0 });
      continue;
    }
    const shared = [...dsk.get(table)].filter((c) => web.get(table).has(c)).sort();
    const desktopOnly = [...dsk.get(table)].filter((c) => !web.get(table).has(c)).sort();
    if (desktopOnly.length) {
      problems.push(`${table}: desktop columns absent in web: ${desktopOnly.join(', ')}`);
    }
    if (!shared.length) {
      summary.push({ table, status: 'no-shared-columns', rows: 0 });
      continue;
    }

    const where = company && dsk.get(table).has('CO_CODE') ? ` WHERE [CO_CODE]=@co` : '';
    const req = pool.request();
    if (where) req.input('co', mssql.NVarChar(10), company);
    const rows = (
      await req.query(`SELECT ${shared.map((c) => `[${c}]`).join(',')} FROM [${table}]${where}`)
    ).recordset;

    if (!rows.length) {
      summary.push({ table, status: 'empty-on-desktop', rows: 0 });
      continue;
    }

    // Insert in batches. Values are parameterised; identifiers are validated above.
    const cols = ['tenant_id', ...shared];
    const BATCH = 200;
    let written = 0;
    for (let i = 0; i < rows.length; i += BATCH) {
      const chunk = rows.slice(i, i + BATCH);
      const params = [];
      const tuples = chunk.map((row) => {
        const slot = [];
        params.push(tenant);
        slot.push(`$${params.length}`);
        for (const c of shared) {
          let v = row[c];
          // Dates go over as ISO strings and are cast back by the destination column's type; bigint is not
          // JSON/driver-safe. Empty strings in a date column must become NULL, not ''::date, which errors.
          if (v instanceof Date) v = v.toISOString();
          if (typeof v === 'bigint') v = Number(v);
          const cast = castFor(table, c);
          if (v === '' && cast && cast !== '::text') v = null;
          params.push(v === undefined ? null : v);
          slot.push(`$${params.length}${cast}`);
        }
        return `(${slot.join(',')})`;
      });
      await prisma.$executeRawUnsafe(
        `INSERT INTO ${q(table)} (${cols.map(q).join(',')}) VALUES ${tuples.join(',')}
         ON CONFLICT DO NOTHING`,
        ...params,
      );
      written += chunk.length;
    }
    summary.push({ table, status: 'copied', rows: written, columns: shared.length });
  }

  console.log('\n table                 status              rows  cols');
  console.log(' --------------------- ------------------ ----- -----');
  for (const s of summary) {
    console.log(
      ` ${s.table.padEnd(21)} ${s.status.padEnd(18)} ${String(s.rows).padStart(5)} ${String(s.columns ?? '').padStart(5)}`,
    );
  }
  const copied = summary.filter((s) => s.status === 'copied');
  console.log(
    `\ncopied ${copied.reduce((n, s) => n + s.rows, 0)} row(s) across ${copied.length} master table(s) into tenant ${tenant}`,
  );

  if (problems.length) {
    console.warn('\nSCHEMA NOTES (not necessarily fatal, but do not ignore):');
    for (const p of problems) console.warn('  ! ' + p);
  }

  await pool.close();
  await prisma.$disconnect();
  console.log(problems.length ? 'IMPORT_OK_WITH_NOTES' : 'IMPORT_OK');
}

main().catch(async (e) => {
  console.error('IMPORT_FAIL', e?.message ?? e);
  console.error(
    String(e?.stack ?? '')
      .split('\n')
      .slice(1, 5)
      .join('\n'),
  );
  process.exit(1);
});
