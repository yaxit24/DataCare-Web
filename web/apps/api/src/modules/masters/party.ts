import { withTenant } from '@datacare/db';

/**
 * Party extras (desktop party form tabs): PHOTO (AC_IMAGE bytea, keyed by CO_CODE+AC_CODE) and FAMILY
 * (accounts sharing the same AC_KHATA_NO — the family/khata ledger group). Inline opening-at-create
 * reuses masters.setOpeningBalance. Additive; RLS-scoped.
 */
export async function setPartyPhoto(
  prisma: any,
  scope: { tenantId: string; coCode: string; lcCode?: string },
  acCode: string,
  dataUrl: string,
): Promise<{ saved: true }> {
  if (!acCode) throw new Error('acCode is required');
  const b64 = String(dataUrl || '').replace(/^data:[^;]+;base64,/, '');
  const buf = Buffer.from(b64, 'base64');
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    await tx.$executeRawUnsafe(
      `DELETE FROM "AC_IMAGE" WHERE "CO_CODE"=$1 AND "AC_CODE"=$2`,
      scope.coCode,
      acCode,
    );
    await tx.$executeRawUnsafe(
      `INSERT INTO "AC_IMAGE"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_IMAGE") VALUES ($1,$2,$3,$4,$5)`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode ?? '01',
      acCode,
      buf,
    );
    return { saved: true };
  });
}

export async function getPartyPhoto(
  prisma: any,
  scope: { tenantId: string; coCode: string },
  acCode: string,
): Promise<{ dataUrl: string | null }> {
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "AC_IMAGE" img FROM "AC_IMAGE" WHERE "CO_CODE"=$1 AND "AC_CODE"=$2 LIMIT 1`,
      scope.coCode,
      acCode,
    );
    const img = rows[0]?.img;
    if (!img) return { dataUrl: null };
    const buf = Buffer.isBuffer(img) ? img : Buffer.from(img as any);
    if (!buf.length) return { dataUrl: null };
    return { dataUrl: `data:image/*;base64,${buf.toString('base64')}` };
  });
}

export interface FamilyMember {
  acCode: string;
  acName: string;
  mobile: string;
}
export async function familyMembers(
  prisma: any,
  scope: { tenantId: string; coCode: string },
  acCode: string,
): Promise<{ khataNo: string; members: FamilyMember[] }> {
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const kr: any[] = await tx.$queryRawUnsafe(
      `SELECT coalesce("AC_KHATA_NO",'') k FROM "AC_MAST" WHERE "CO_CODE"=$1 AND "AC_CODE"=$2 LIMIT 1`,
      scope.coCode,
      acCode,
    );
    const khata = String(kr[0]?.k ?? '').trim();
    if (!khata) return { khataNo: '', members: [] };
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "AC_CODE" ac, coalesce("AC_NAME",'') nm, coalesce("AC_MOBILE",'') mo FROM "AC_MAST" WHERE "CO_CODE"=$1 AND coalesce("AC_KHATA_NO",'')=$2 ORDER BY "AC_CODE"`,
      scope.coCode,
      khata,
    );
    return {
      khataNo: khata,
      members: rows.map((r) => ({
        acCode: String(r.ac),
        acName: String(r.nm),
        mobile: String(r.mo),
      })),
    };
  });
}
