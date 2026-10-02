import type { PrismaClient } from '@datacare/db';
import {
  CompanyBackupValidationError,
  assertCompanyBackupIntegrity,
  backupCompany,
  type CompanyBackup,
} from './backup.js';

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

/**
 * Re-read a restored company through the runtime RLS role and compare exact v2 SHA-256 table digests.
 * Technical row IDs and authenticated scope values are included; unlike the legacy cross-scope MD5 helper,
 * this cannot report equality after identity or company keys change.
 */
export async function verifyCompanyRestore(
  prisma: PrismaClient,
  expected: CompanyBackup,
  target: { tenantId: string; companyCode: string },
): Promise<RestoreVerification> {
  assertCompanyBackupIntegrity(expected);
  if (
    expected.source.tenantId !== target.tenantId ||
    expected.source.companyCode !== target.companyCode
  )
    throw new CompanyBackupValidationError(
      'restore verification target must match the backup tenant and company',
    );
  const restored = await backupCompany(prisma, target.tenantId, target.companyCode);
  const tables: CompanyTableDigest[] = Object.keys(expected.tables)
    .sort()
    .map((table) => {
      const source = expected.tables[table]!;
      const actual = restored.tables[table];
      return {
        table,
        sourceRows: source.rowCount,
        restoredRows: actual?.rowCount ?? -1,
        sourceChecksum: source.checksum,
        restoredChecksum: actual?.checksum ?? '',
        matches: source.rowCount === actual?.rowCount && source.checksum === actual?.checksum,
      };
    });
  const mismatches = tables.filter((table) => !table.matches).map((table) => table.table);
  return {
    verified: mismatches.length === 0,
    source: {
      tenantId: expected.source.tenantId,
      companyCode: expected.source.companyCode,
    },
    target,
    sourceRows: expected.totals.rows,
    restoredRows: restored.totals.rows,
    tablesChecked: tables.length,
    mismatches,
    tables,
  };
}
