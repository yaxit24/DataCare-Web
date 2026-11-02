import { type PrismaClient, withTenant } from '@datacare/db';

const two = (value: number): string => String(value).padStart(2, '0');

export interface BackupFilenameInput {
  fiscalYear: string;
  companyType?: string | null;
  now?: Date;
}

/**
 * Reproduce UT_BKP.cs:1216-1248 without accepting a browser path or other request input.
 * The API process uses its configured local business clock, matching desktop DateAndTime.Now; the suggestion
 * stays stable for the whole hour.
 */
export function buildBackupFilename({
  fiscalYear,
  companyType,
  now = new Date(),
}: BackupFilenameInput): string {
  const year = fiscalYear.match(/\d{4}/)?.[0];
  if (!year) throw new Error('authenticated fiscal year is required for a backup filename');
  const type = (companyType ?? '')
    .trim()
    .toUpperCase()
    .replace(/[^A-Z0-9]+/g, '-')
    .replace(/^-+|-+$/g, '')
    .slice(0, 24);
  const stamp = `${two(now.getDate())}${two(now.getMonth() + 1)}${two(
    now.getFullYear() % 100,
  )}_${two(now.getHours())}`;
  return `Next${year.slice(-2)}${type ? `_${type}` : ''}_${stamp}.json`;
}

/** Read the selected company's persisted type. Ambiguous or blank values deliberately omit the segment. */
export async function loadBackupCompanyType(
  prisma: PrismaClient,
  tenantId: string,
  companyCode: string,
): Promise<string | undefined> {
  return withTenant(prisma, tenantId, async (tx) => {
    const rows = await tx.$queryRawUnsafe<Array<{ type: string }>>(
      `SELECT DISTINCT upper(btrim("CO_TYPE")) AS type
         FROM "CO_MAST"
        WHERE tenant_id=$1 AND "CO_CODE"::text=$2::text
          AND NULLIF(btrim("CO_TYPE"),'') IS NOT NULL`,
      tenantId,
      companyCode,
    );
    return rows.length === 1 ? rows[0]?.type : undefined;
  });
}
