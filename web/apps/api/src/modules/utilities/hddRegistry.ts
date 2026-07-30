import { withTenant } from '@datacare/db';

export interface UtilityScope {
  tenantId: string;
  coCode: string;
  lcCode: string;
  coYear?: string;
}

export interface HddRegistryRow {
  id: string;
  refNo: string;
}

export class HddRegistryValidationError extends Error {
  override name = 'HddRegistryValidationError';
}

function refNoOf(value: unknown): string {
  const refNo = String(value ?? '').trim();
  // The desktop textbox allows 50 characters (UT_HDD.cs:617), but HDD_MAST.REF_NO is varchar(10).
  // Desktop has no empty-value validation and replaces the table with exactly tHddNo.Text
  // (UT_HDD.cs:762-765), so empty remains a valid source-compatible value.
  if (refNo.length > 10)
    throw new HddRegistryValidationError('REF_NO must be at most 10 characters');
  return refNo;
}

export async function listHddRegistry(prisma: any, scope: UtilityScope): Promise<HddRegistryRow[]> {
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    // HDD_MAST has no CO_CODE/LC_CODE columns. The web port therefore applies the strongest
    // available server-derived scope: tenant RLS plus an explicit tenant predicate.
    const rows: Array<{ id: bigint; refNo: string | null }> = await tx.$queryRawUnsafe(
      `SELECT "row_id" AS id, "REF_NO" AS "refNo"
         FROM "HDD_MAST" WHERE tenant_id=$1 ORDER BY "row_id"`,
      scope.tenantId,
    );
    return rows.map((row) => ({ id: String(row.id), refNo: row.refNo ?? '' }));
  });
}

export async function getHddRegistry(
  prisma: any,
  scope: UtilityScope,
  refNo: string,
): Promise<HddRegistryRow | null> {
  const rows = await listHddRegistry(prisma, scope);
  return rows.find((row) => row.refNo === refNo) ?? null;
}

export async function saveHddRegistry(
  prisma: any,
  scope: UtilityScope,
  refNoInput: unknown,
): Promise<{ refNo: string; message: string }> {
  const refNo = refNoOf(refNoInput);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    // Exact desktop write set/value source: DELETE all then INSERT HDD_MAST(REF_NO)=tHddNo.Text;
    // success text is "Hdd Is Update..." (UT_HDD.cs:762-765). Tenant predicates adapt the legacy
    // global table safely; the transaction makes the replacement atomic.
    await tx.$executeRawUnsafe(`DELETE FROM "HDD_MAST" WHERE tenant_id=$1`, scope.tenantId);
    await tx.$executeRawUnsafe(
      `INSERT INTO "HDD_MAST"(tenant_id,"REF_NO") VALUES ($1,$2)`,
      scope.tenantId,
      refNo,
    );
    return { refNo, message: 'Hdd Is Update...' };
  });
}

export async function deleteHddRegistry(
  prisma: any,
  scope: UtilityScope,
  refNo: string,
): Promise<{ deleted: number }> {
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const deleted = await tx.$executeRawUnsafe(
      `DELETE FROM "HDD_MAST" WHERE tenant_id=$1 AND COALESCE("REF_NO",'')=$2`,
      scope.tenantId,
      refNo,
    );
    return { deleted };
  });
}
