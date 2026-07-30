import { withTenant } from '@datacare/db';
import { COMPANY_BACKUP_TABLES } from './backup.js';

const qid = (value: string): string => `"${value.replace(/[^A-Za-z0-9_]/g, '')}"`;

export interface CompanyTableDigest {
  table: string;
  sourceRows: number;
  restoredRows: number;
  sourceChecksum: string;
  restoredChecksum: string;
  matches: boolean;
}

export interface RestoreVerification {
  verified: boolean;
  source: { tenantId: string; companyCode: string };
  target: { tenantId: string; companyCode: string };
  sourceRows: number;
  restoredRows: number;
  tablesChecked: number;
  mismatches: string[];
  tables: CompanyTableDigest[];
}

async function companyOwnedTables(prisma: any, requested: readonly string[]): Promise<string[]> {
  const rows: Array<{ table_name: string }> = await prisma.$queryRawUnsafe(
    `SELECT table_name
       FROM information_schema.columns
      WHERE table_schema='public'
        AND column_name='CO_CODE'
        AND table_name = ANY($1::text[])
      ORDER BY table_name`,
    [...requested],
  );
  const allowed = new Set(requested);
  return rows.map((row) => row.table_name).filter((table) => allowed.has(table));
}

async function digest(
  prisma: any,
  tenantId: string,
  companyCode: string,
  table: string,
): Promise<{ rows: number; checksum: string }> {
  return withTenant(prisma, tenantId, async (tx: any) => {
    const result: Array<{ rows: unknown; checksum: string }> = await tx.$queryRawUnsafe(
      `SELECT COUNT(*)::int AS rows,
              md5(COALESCE(string_agg(normalized, '|' ORDER BY normalized), '')) AS checksum
         FROM (
           SELECT (to_jsonb(t) - 'tenant_id' - 'row_id' - 'CO_CODE')::text AS normalized
             FROM ${qid(table)} t
            WHERE "CO_CODE"::text=$1::text
         ) digest_rows`,
      companyCode,
    );
    return {
      rows: Number(result[0]?.rows ?? 0),
      checksum: String(result[0]?.checksum ?? ''),
    };
  });
}

/** Compare company-owned rows through the runtime role; volatile tenant/company/serial keys are ignored. */
export async function verifyCompanyRestore(
  prisma: any,
  source: { tenantId: string; companyCode: string },
  target: { tenantId: string; companyCode: string },
  options: { tables?: readonly string[] } = {},
): Promise<RestoreVerification> {
  const requested = options.tables ?? COMPANY_BACKUP_TABLES;
  const tables = await companyOwnedTables(prisma, requested);
  const results: CompanyTableDigest[] = [];
  for (const table of tables) {
    const [before, after] = await Promise.all([
      digest(prisma, source.tenantId, source.companyCode, table),
      digest(prisma, target.tenantId, target.companyCode, table),
    ]);
    results.push({
      table,
      sourceRows: before.rows,
      restoredRows: after.rows,
      sourceChecksum: before.checksum,
      restoredChecksum: after.checksum,
      matches: before.rows === after.rows && before.checksum === after.checksum,
    });
  }
  const mismatches = results.filter((row) => !row.matches).map((row) => row.table);
  return {
    verified: mismatches.length === 0 && tables.length > 0,
    source,
    target,
    sourceRows: results.reduce((sum, row) => sum + row.sourceRows, 0),
    restoredRows: results.reduce((sum, row) => sum + row.restoredRows, 0),
    tablesChecked: results.length,
    mismatches,
    tables: results,
  };
}
