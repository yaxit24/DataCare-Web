#!/usr/bin/env node
import { mkdir, writeFile } from 'node:fs/promises';
import { dirname, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import { PrismaClient } from '../packages/db/dist/index.js';
import { backupCompany, restoreCompany } from '../apps/api/dist/modules/ops/backup.js';
import { parityContainmentProblem } from '../packages/core/containment.mjs';

const containment = parityContainmentProblem('logical-restore');
if (containment) {
  process.stdout.write(`${JSON.stringify(containment.body, null, 2)}\n`);
  process.exit(1);
}

const here = dirname(fileURLToPath(import.meta.url));
const root = resolve(here, '..');
const databaseUrl = process.env.DATABASE_URL;
if (!databaseUrl) throw new Error('restore drill requires DATABASE_URL');
const parsedUrl = new URL(databaseUrl);
// The isolated database from scripts/parity-test-env.mjs (PARITY_TEST_PORT, default 55433; N49).
const isolatedPort = process.env.PARITY_TEST_PORT?.trim() || '55433';
if (parsedUrl.hostname !== '127.0.0.1' || parsedUrl.port !== isolatedPort) {
  throw new Error(`restore drill is restricted to PostgreSQL 127.0.0.1:${isolatedPort}`);
}

const source = {
  tenantId: process.env.DR_SOURCE_TENANT ?? 'restore-drill-source',
  companyCode: process.env.DR_SOURCE_COMPANY ?? '01',
};
const target = {
  tenantId: process.env.DR_TARGET_TENANT ?? source.tenantId,
  companyCode: process.env.DR_TARGET_COMPANY ?? source.companyCode,
};
if (target.tenantId !== source.tenantId || target.companyCode !== source.companyCode) {
  throw new Error('v2 company restore drill requires the same source and target tenant/company');
}
const reportPath = resolve(
  root,
  process.env.DR_REPORT_PATH ?? '../project-memory/parity/restore-drill-result.json',
);
const prisma = new PrismaClient({ datasources: { db: { url: databaseUrl } } });

async function seedSource() {
  await prisma.$transaction(async (tx) => {
    await tx.$executeRawUnsafe("SELECT set_config('app.tenant_id', $1, true)", source.tenantId);
    for (const table of ['AC_MAST', 'YEAR_MAST', 'LOCT_MAST', 'CO_SET', 'CO_MAST']) {
      await tx.$executeRawUnsafe(
        `DELETE FROM "${table}" WHERE "CO_CODE"::text=$1::text`,
        source.companyCode,
      );
    }
    await tx.$executeRawUnsafe(
      `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME","LC_CODE") VALUES ($1,$2,'Restore Drill Company','01')`,
      source.tenantId,
      source.companyCode,
    );
    await tx.$executeRawUnsafe(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE") VALUES ($1,$2,NULL)`,
      source.tenantId,
      source.companyCode,
    );
    await tx.$executeRawUnsafe(
      `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME") VALUES ($1,$2,'01','Drill Main')`,
      source.tenantId,
      source.companyCode,
    );
    await tx.$executeRawUnsafe(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR") VALUES ($1,$2,'2026')`,
      source.tenantId,
      source.companyCode,
    );
    await tx.$executeRawUnsafe(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME") VALUES ($1,$2,'01','DRLCASH','Drill Cash')`,
      source.tenantId,
      source.companyCode,
    );
  });
}

const elapsedMs = (started) => Math.round((performance.now() - started) * 1000) / 1000;

async function main() {
  const totalStarted = performance.now();
  await seedSource();

  const backupStarted = performance.now();
  const backup = await backupCompany(prisma, source.tenantId, source.companyCode);
  const backupMs = elapsedMs(backupStarted);

  await prisma.$transaction(async (tx) => {
    await tx.$executeRawUnsafe("SELECT set_config('app.tenant_id', $1, true)", target.tenantId);
    await tx.$executeRawUnsafe(
      `UPDATE "AC_MAST" SET "AC_NAME"='Restore Drill Mutation'
        WHERE "CO_CODE"::text=$1::text AND "AC_CODE"='DRLCASH'`,
      target.companyCode,
    );
  });

  const restoreStarted = performance.now();
  const restore = await restoreCompany(prisma, target, backup, { mode: 'replace' });
  const restoreMs = elapsedMs(restoreStarted);

  const verifyStarted = performance.now();
  const restoredBackup = await backupCompany(prisma, target.tenantId, target.companyCode);
  const verificationTables = Object.keys(backup.tables)
    .sort()
    .map((table) => ({
      table,
      sourceRows: backup.tables[table].rowCount,
      restoredRows: restoredBackup.tables[table]?.rowCount ?? -1,
      sourceChecksum: backup.tables[table].checksum,
      restoredChecksum: restoredBackup.tables[table]?.checksum ?? '',
      matches:
        backup.tables[table].rowCount === restoredBackup.tables[table]?.rowCount &&
        backup.tables[table].checksum === restoredBackup.tables[table]?.checksum,
    }));
  const mismatches = verificationTables
    .filter((table) => !table.matches)
    .map((table) => table.table);
  const verification = {
    verified: mismatches.length === 0,
    source,
    target,
    sourceRows: backup.totals.rows,
    restoredRows: restoredBackup.totals.rows,
    tablesChecked: verificationTables.length,
    mismatches,
    tables: verificationTables,
  };
  const verifyMs = elapsedMs(verifyStarted);
  const completedAt = new Date();
  const recoveryPointAgeMs = Math.max(0, completedAt.getTime() - Date.parse(backup.generatedAt));

  const result = {
    status: verification.verified ? 'passed' : 'failed',
    measuredAt: completedAt.toISOString(),
    database: {
      host: parsedUrl.hostname,
      port: Number(parsedUrl.port),
      name: parsedUrl.pathname.slice(1),
    },
    source,
    target,
    backup: { generatedAt: backup.generatedAt, rows: backup.totals.rows, durationMs: backupMs },
    restore: { ...restore, durationMs: restoreMs },
    verification,
    measured: {
      rpo: { snapshotDataLossRows: 0, recoveryPointAgeMs },
      rtoMs: elapsedMs(totalStarted),
      verifyMs,
    },
  };
  await mkdir(dirname(reportPath), { recursive: true });
  await writeFile(reportPath, `${JSON.stringify(result, null, 2)}\n`, 'utf8');
  console.log(JSON.stringify(result, null, 2));
  if (!verification.verified)
    throw new Error(`RESTORE_DRILL_MISMATCH: ${verification.mismatches.join(',')}`);
  console.log(`RESTORE_DRILL_OK report=${reportPath}`);
}

main()
  .catch((error) => {
    console.error(
      `RESTORE_DRILL_FAILED: ${error instanceof Error ? error.message : String(error)}`,
    );
    process.exitCode = 1;
  })
  .finally(() => prisma.$disconnect());
