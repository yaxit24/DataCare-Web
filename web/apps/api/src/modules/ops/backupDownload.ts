import type { CompanyBackupDocument } from './backupManifest.js';
import { buildBackupFilename } from './backupFilename.js';

export interface BackupDownloadDependencies {
  now?(): Date;
  generate(): Promise<CompanyBackupDocument>;
  loadCompanyType(): Promise<string | undefined>;
  record(document: CompanyBackupDocument): Promise<void>;
}

/**
 * Capture the filename clock before generation, then preserve archive metadata and audit ordering.
 * This matches UT_BKP.cs:1216-1248 constructing the target path before starting the backup.
 */
export async function prepareBackupDownload(
  fiscalYear: string,
  dependencies: BackupDownloadDependencies,
): Promise<{ data: CompanyBackupDocument; filename: string }> {
  const filenameTime = dependencies.now?.() ?? new Date();
  const data = await dependencies.generate();
  const companyType = await dependencies.loadCompanyType();
  const filename = buildBackupFilename({ fiscalYear, companyType, now: filenameTime });
  await dependencies.record(data);
  return { data, filename };
}
