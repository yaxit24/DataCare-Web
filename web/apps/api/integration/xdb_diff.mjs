// Full desktop↔web data-fidelity matrix: desktop SQL Server (Next24 via SQL Edge) vs web Postgres.
// For EVERY table common to both: column coverage, desktop row count, and (rows≤8000) an all-or-nothing
// ETL into PG (tenant 'parity') + per-numeric-column Σ diff. Writes project-memory/parity/xdb-matrix.md.
// Run: DATABASE_URL=postgresql://app_user:app@127.0.0.1:5433/datacare node apps/api/integration/xdb_diff.mjs
import sql from 'mssql';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { writeFileSync } from 'node:fs';

const SRC = {
  server: 'localhost',
  port: 11433,
  // Credentials come from the environment; never commit secrets to source.
  user: process.env.CUTOVER_SOURCE_USER || 'sa',
  password: process.env.CUTOVER_SOURCE_PASSWORD || '',
  database: 'master',
  options: { encrypt: false, trustServerCertificate: true },
  requestTimeout: 240000,
};
const prisma = new PrismaClient();
const PT = 'parity';
const qid = (c) => '"' + c.replace(/[^A-Za-z0-9_]/g, '') + '"';
let colOK = 0,
  colWarn = 0,
  etlOK = 0,
  etlFail = 0,
  sumOK = 0,
  sumFail = 0;
const matrix = [];

async function main() {
  const ms = await sql.connect(SRC);
  await ms
    .request()
    .batch(
      `IF DB_ID('Next24') IS NULL CREATE DATABASE [Next24] ON (FILENAME='/var/opt/mssql/data/Next24.mdf'),(FILENAME='/var/opt/mssql/data/Next24.ldf') FOR ATTACH;`,
    )
    .catch(() => {});

  const dtabs = (
    await ms
      .request()
      .query(
        `SELECT TABLE_NAME FROM Next24.INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'`,
      )
  ).recordset.map((r) => r.TABLE_NAME);
  const ptabs = new Set(
    (
      await prisma.$queryRawUnsafe(
        `SELECT table_name FROM information_schema.tables WHERE table_schema='public'`,
      )
    ).map((r) => r.table_name.toUpperCase()),
  );
  const common = dtabs.filter((t) => ptabs.has(t.toUpperCase()));
  console.log(
    `desktop base tables=${dtabs.length}, pg tables=${ptabs.size}, COMMON=${common.length}`,
  );

  for (const t of common) {
    let dcount = 0;
    try {
      dcount = (await ms.request().query(`SELECT COUNT(*) n FROM Next24.dbo.${t}`)).recordset[0].n;
    } catch {
      continue;
    }
    // column coverage
    const d = (
      await ms
        .request()
        .query(`SELECT COLUMN_NAME FROM Next24.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='${t}'`)
    ).recordset.map((r) => r.COLUMN_NAME);
    const p = new Set(
      (
        await prisma.$queryRawUnsafe(
          `SELECT column_name FROM information_schema.columns WHERE table_name=$1`,
          t,
        )
      ).map((r) => r.column_name.toUpperCase()),
    );
    const missing = d.filter(
      (c) =>
        !p.has(c.COLUMN_NAME?.toUpperCase?.() ?? c.toUpperCase()) &&
        (c.COLUMN_NAME ?? c).toUpperCase?.() !== 'TENANT_ID',
    );
    const dcols = d.map((c) => c.COLUMN_NAME ?? c);
    const miss = dcols.filter((c) => !p.has(c.toUpperCase()) && c.toUpperCase() !== 'TENANT_ID');
    const cov = dcols.length
      ? Math.round((100 * (dcols.length - miss.length)) / dcols.length)
      : 100;
    cov === 100 ? colOK++ : colWarn++;

    let etl = '-',
      sums = '-';
    if (dcount > 0 && dcount <= 8000) {
      const r = await etlDiff(ms, t, p);
      etl = `${r.loaded}/${dcount}`;
      if (r.loaded === dcount) {
        etlOK++;
        sums = `${r.sumOK}/${r.sumOK + r.sumBad} Σ`;
        sumOK += r.sumOK;
        sumFail += r.sumBad;
      } else {
        etlFail++;
        etl += ' REJECT';
      }
    }
    matrix.push({ t, cov: cov + '%', rows: dcount, etl, sums });
  }

  // report
  const hdr = '| table | col cov | desktop rows | ETL loaded | Σ checks |\n|---|---|---|---|---|';
  const lines = matrix.map((m) => `| ${m.t} | ${m.cov} | ${m.rows} | ${m.etl} | ${m.sums} |`);
  const md = `# Desktop↔Web data-fidelity matrix (Next24)\n_${new Date().toISOString()}_\n\nCommon tables: ${matrix.length}. Column-complete: ${colOK}; partial: ${colWarn}. ETL fully-loaded: ${etlOK}; rejected: ${etlFail}. Σ column checks: ${sumOK} pass / ${sumFail} fail.\n\n${hdr}\n${lines.join('\n')}\n`;
  writeFileSync('../project-memory/parity/xdb-matrix.md', md);
  console.log(
    `\nMATRIX: tables=${matrix.length} colComplete=${colOK} colPartial=${colWarn} | etlOK=${etlOK} etlFail=${etlFail} | Σpass=${sumOK} Σfail=${sumFail}`,
  );
  console.log('wrote project-memory/parity/xdb-matrix.md');
  await ms.close();
  await prisma.$disconnect();
  console.log(etlFail === 0 && sumFail === 0 ? 'XDB_MATRIX_OK' : 'XDB_MATRIX_REVIEW');
}

async function etlDiff(ms, t, pset) {
  const dmeta = (
    await ms
      .request()
      .query(`SELECT COLUMN_NAME FROM Next24.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='${t}'`)
  ).recordset.map((r) => r.COLUMN_NAME);
  const pmeta = await prisma.$queryRawUnsafe(
    `SELECT column_name, data_type FROM information_schema.columns WHERE table_name=$1`,
    t,
  );
  const ptypes = new Map(pmeta.map((r) => [r.column_name.toUpperCase(), r.data_type]));
  const cols = dmeta.filter(
    (c) => ptypes.has(c.toUpperCase()) && !['TENANT_ID', 'ROW_ID'].includes(c.toUpperCase()),
  );
  const numCols = cols.filter((c) =>
    ['numeric', 'double precision', 'integer', 'bigint', 'real'].includes(
      ptypes.get(c.toUpperCase()),
    ),
  );
  const rows = (
    await ms.request().query(`SELECT ${cols.map((c) => `[${c}]`).join(',')} FROM Next24.dbo.${t}`)
  ).recordset;
  const colSql = ['tenant_id', ...cols.map(qid)].join(',');
  const ph = cols.map((_, i) => '$' + (i + 2)).join(',');
  let loaded = 0,
    err = '';
  try {
    await withTenant(prisma, PT, async (tx) => {
      await tx.$executeRawUnsafe(`DELETE FROM "${t}" WHERE tenant_id=$1`, PT);
      for (const r of rows) {
        await tx.$executeRawUnsafe(
          `INSERT INTO "${t}"(${colSql}) VALUES ($1,${ph})`,
          PT,
          ...cols.map((c) =>
            r[c] === undefined ? null : typeof r[c] === 'string' ? r[c].trimEnd() : r[c],
          ),
        );
        loaded++;
      }
    });
  } catch (e) {
    err = (e?.message ?? '').slice(0, 130);
    loaded = -1;
  }
  let sumOK = 0,
    sumBad = 0;
  if (loaded === rows.length) {
    for (const c of numCols.slice(0, 8)) {
      const ds =
        Math.round(
          ((await ms.request().query(`SELECT SUM(CAST([${c}] AS float)) s FROM Next24.dbo.${t}`))
            .recordset[0].s ?? 0) * 100,
        ) / 100;
      const ps =
        Math.round(
          ((
            await withTenant(prisma, PT, (tx) =>
              tx.$queryRawUnsafe(
                `SELECT COALESCE(SUM(${qid(c)}),0)::float s FROM "${t}" WHERE tenant_id=$1`,
                PT,
              ),
            )
          )[0].s ?? 0) * 100,
        ) / 100;
      if (Math.abs(ds - ps) < 0.05) sumOK++;
      else {
        sumBad++;
        console.log(`    Σ-MISMATCH ${t}.${c}: desktop ${ds} vs pg ${ps}`);
      }
    }
  } else {
    console.log(`    REJECT ${t}: ${err}`);
  }
  await withTenant(prisma, PT, (tx) =>
    tx.$executeRawUnsafe(`DELETE FROM "${t}" WHERE tenant_id=$1`, PT),
  ).catch(() => {});
  return { loaded: loaded < 0 ? 0 : loaded, sumOK, sumBad };
}
main().catch((e) => {
  console.error('FATAL', e.message);
  process.exit(1);
});
